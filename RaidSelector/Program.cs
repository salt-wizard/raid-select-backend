#pragma warning disable CA1822, CA1050
using CPHNameSpace;                // Mimic CPH for method references
using static CPHNameSpace.CPHArgs; // Mimic arguments for inline CPH


/************************************************************************
* COPY AND PASTE BELOW CLASS INTO STREAMER.BOT 
* DO NOT COPY ANYTHING OUTSIDE THE BLOCK COMMENT
************************************************************************/
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;
using System.Collections;
using System.Text.RegularExpressions;

public class CPHInline
{

    public void Init()
    {
        // place your init code here
    }

    public void Dispose()
    {
        // place your dispose code here
    }

    public bool Execute()
    {
        // place your main code here

        return true;
    }

    /** 
     * Custom methods go below 
     * 
     * Any method that is to be used by Streamer.Bot must have a reutrn type of bool and no parameters
     **/

    public bool PushUpdatedRaidList()
    {
        /* Grab the WS connection */
        String sessionId = CPH.GetGlobalVar<String>("raidSessionId", true);
        int wssIdx = CPH.GetGlobalVar<int>("raidWssIdx", true);

        // Get current raidlist
        ArrayList raidList = CPH.GetGlobalVar<ArrayList>("raidList", true);

        string rawJson = JsonConvert.SerializeObject(raidList);
        string updatedJson = rawJson.Replace("\\r","");
        updatedJson = updatedJson.Replace("\\n", "").Replace("\\\"", "\"").Replace("}\"", "}").Replace("\"{", "{").Replace(" ", "");

        // Broadcast the JSON message
        CPH.WebsocketCustomServerBroadcast(updatedJson, sessionId, wssIdx);

        return true;
    }


    /**
     * Loads the blacklist from the specified file and puts it into a list for the user
     **/
    public bool InitBlackList()
    {
        ArrayList blackList = new ArrayList();

        //PrintArgsVerbose();

        // Make sure that lineCount exists in the args otherwise there will be a crash
        if(null != args["lineCount"])
        {
            int lineCount = (int)args["lineCount"];
            for (int i = 0; i < lineCount; i++)
            {
                blackList.Add(args["line" + i]);
            }
        }

        CPH.SetGlobalVar("raidBlackList", blackList, true);

        return true;
    }

    /**
     * Instantiates a new raid list for the user when invoked.
     **/
    public bool InitRaidList()
    {
        ArrayList raidList = new ArrayList();
        ArrayList raidTextList = new ArrayList();

        CPH.SetGlobalVar("raidList", raidList, true);
        CPH.SetGlobalVar("raidTextList", raidList, true);

        return true;
    }

    /**
     * Checks to see if the user is part of the blacklist.
     * True if blacklisted, False if not.
     * */
    public bool IsTargetBlackListed()
    {
        bool blackListed = false;
        string userName = (string)args["userName"];
        string raidTarget = (string)args["raidTarget"];

        //PrintArgsVerbose();

        ArrayList blackList = CPH.GetGlobalVar<ArrayList>("raidBlackList", true);
        CPH.LogDebug("Blacklisted users ----- ");
        foreach (string item in blackList)
        {
            CPH.LogDebug("user :: " + item);
        }

        
        blackListed = blackList.Contains(raidTarget);
        if( blackListed)
        {
            CPH.LogDebug("The user is blacklisted; will not add to list.");
        }
        else
        {
            CPH.LogDebug("The user is NOT blacklisted. Continuing...");
        }

        return blackListed;
    }

    /**
     * Checks to see if the user was already suggested.
     * True if suggested, False if not.
     * */
    public bool IsTargetedSuggested()
    {
        bool alreadySuggested = false;
        string userName = (string)args["userName"];
        string raidTarget = (string)args["raidTarget"];

        //PrintArgsVerbose();

        ArrayList raidTextList = CPH.GetGlobalVar<ArrayList>("raidTextList", true);
        CPH.LogDebug("Suggested users ----- ");
        foreach (string item in raidTextList)
        {
            CPH.LogDebug("user :: " + item);
        }

        alreadySuggested = raidTextList.Contains(raidTarget);

        if (alreadySuggested)
        {
            CPH.LogDebug("The target has already been suggested.");
        } else
        {
            CPH.LogDebug("The target hasn't been suggested yet; adding to list.");
        }

        return alreadySuggested;
    }

    /**
     * Validate if the user has been following for enough time 
     **/
    public bool CanUserSuggest()
    {
        bool valid = false;

        //PrintArgsVerbose();

        Boolean isFollowing = (Boolean)args["isFollowing"];
        
        if (isFollowing)
        {
            CPH.LogDebug("The user is following.");
            int followAgeDays = Int32.Parse((string)args["followAgeDays"]);
            CPH.LogDebug("The user has been following for " + followAgeDays + " days.");
            if(followAgeDays >= 31)
            {
                valid = true;
            }
        }

        return valid;
    }


    /**
     * Validates if the raid target is online. 
     **/
    public bool IsTargetOnline()
    {
        bool targetOnline = false;

        PrintArgsVerbose();

        string targetPageResults = (string)args["targetPageResults"];

        if (targetPageResults != null)
        {
            targetOnline = targetPageResults.Contains("\"isLiveBroadcast\":true");
        }

        if(targetOnline)
        {
            CPH.LogDebug("Target is online!");
        } else
        {
            CPH.LogDebug("TARGET IS NOT ONLINE!!!");
        }

        return targetOnline;
    }

    public bool AddTargetToList()
    {
        string raidTarget = (string)args["raidTarget"];
        string profilePage = (string)args["profilePage"];

        ArrayList raidList = CPH.GetGlobalVar<ArrayList>("raidList", true);
        ArrayList raidTextList = CPH.GetGlobalVar<ArrayList>("raidTextList", true);


        // Create a JSON for the raid target
        dynamic jsonObject = new JObject();
        jsonObject.name = raidTarget;
        jsonObject.pfp = GetTargetPFP(profilePage);

        // Needs to be added as a String
        string jsonString = jsonObject.ToString();
        CPH.LogDebug("Json string being added :: ");
        CPH.LogDebug(jsonString);
        raidList.Add(jsonString);
        raidTextList.Add(raidTarget);
        CPH.LogDebug("The target hasn't been suggested yet; adding to list.");

        CPH.SetGlobalVar("raidList", raidList, true);
        CPH.SetGlobalVar("raidTextList", raidTextList, true);

        return true;
    }

    // Return the target's PFP image URL using the URL page (doesn't require authentication)
    // Is there a better way of doing this? Yes. I don't really care though.
    private string GetTargetPFP(string input)
    {
        string pfp = "";
        string pattern = @"https://static-cdn.jtvnw.net/jtv_user_pictures/([A-Za-z0-9\-]+)-profile_image-300x300.png";

        if (input != null)
        {
            CPH.LogDebug("Input not null");
            Match m = Regex.Match(input, pattern, RegexOptions.IgnoreCase);
            if (m.Success)
            {
                pfp = m.Value;
                CPH.LogDebug("Profile URL :: " + pfp);
            }
        }

        return pfp;
    }

    public bool StartRandomRaid()
    {
        bool randomRaid = false;
        string data = (string)args["data"];
        if(data != null)
        {
            CPH.LogVerbose("StartRandomRaid --  data :: " + data);
            dynamic json = JObject.Parse(data);
            string action = json.action;
            if (action != null && action.Equals("raid"))
            {
                CPH.LogDebug("StartRandomRaid -- RANDOM RAID IS BEING INVOKED");
                randomRaid = true;

                //CPH.TwitchStartRaidByName();
            }
        }

        return randomRaid;
    }

    public bool CancelRaidVerify()
    {
        //PrintArgsVerbose();

        var data = args["data"];
        CPH.LogDebug("Data :: " + data);

        if (data.Equals("CANCELRAID"))
        {
            CPH.LogDebug("Canceling raid...");
            return true;
        } else
        {
            CPH.LogVerbose("Invalid command, ignoring...");
            return false;
        }
    }


    /**
     * HELPER METHODS BELOW
     **/
    public string ObjToString(object obj)
    {
        return JsonConvert.SerializeObject(obj, Formatting.Indented, new JsonConverter[] { new StringEnumConverter() });
    }

    public void PrintArgsVerbose()
    {
        CPH.LogVerbose($"Arguments being passed in...");
        foreach (var arg in args)
        {
            CPH.LogVerbose($"{arg.Key} :: {arg.Value}");
        }
    }
}
/************************************************************************
* COPY AND PASTE ABOVE CLASS INTO STREAMER.BOT
* DO NOT COPY ANYTHING OUTSIDE THE BLOCK COMMENT
************************************************************************/
#pragma warning restore CA1822, CA1050