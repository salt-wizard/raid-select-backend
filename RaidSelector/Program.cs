#pragma warning disable CA1822, CA1050
using CPHNameSpace;                // Mimic CPH for method references
using static CPHNameSpace.CPHArgs; // Mimic arguments for inline CPH


/************************************************************************
* COPY AND PASTE BELOW CLASS INTO STREAMER.BOT 
* DO NOT COPY ANYTHING OUTSIDE THE BLOCK COMMENT
************************************************************************/
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections;

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

    /**
     * Loads the blacklist from the specified file and puts it into a list for the user
     **/
    public bool initBlackList()
    {
        ArrayList blackList = new ArrayList();

        printArgsVerb();

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
    public bool initRaidList()
    {
        ArrayList raidList = new ArrayList();

        CPH.SetGlobalVar("raidList", raidList, true);

        return true;
    }

    /**
     * Checks to see if the user is part of the blacklist.
     * True if blacklisted, False if not.
     * */
    public bool isTargetBlackListed()
    {
        bool blackListed = false;
        string userName = (string)args["userName"];
        string raidTarget = (string)args["raidTarget"];

        printArgsVerb();

        ArrayList blackList = CPH.GetGlobalVar<ArrayList>("raidBlackList", true);
        CPH.LogVerbose("Blacklisted users ----- ");
        foreach (string item in blackList)
        {
            CPH.LogVerbose("user :: " + item);
        }

        // We do not 
        blackListed = blackList.Contains(raidTarget);
        return blackListed;
    }

    /**
     * Checks to see if the user was already suggested.
     * True if suggested, False if not.
     * */
    public bool isTargetedSuggested()
    {
        bool alreadySuggested = false;
        string userName = (string)args["userName"];
        string raidTarget = (string)args["raidTarget"];

        printArgsVerb();

        ArrayList raidList = CPH.GetGlobalVar<ArrayList>("raidList", true);
        CPH.LogVerbose("Suggested users ----- ");
        foreach (string item in raidList)
        {
            CPH.LogVerbose("user :: " + item);
        }

        alreadySuggested = raidList.Contains(raidTarget);

        if (alreadySuggested)
        {
            CPH.SendMessage("@" + userName + " the suggestion " + raidTarget + " has already been made. Please make another suggestion.");
        }

        return alreadySuggested;
    }


    /**
     * Validates if the raid target is online. 
     **/
    public bool isTargetOnline()
    {
        bool targetOnline = false;

        printArgsVerb();

        return targetOnline;
    }


    /**
     * HELPER METHODS BELOW
     **/
    public string ObjToString(object obj)
    {
        return JsonConvert.SerializeObject(obj, Formatting.Indented, new JsonConverter[] { new StringEnumConverter() });
    }

    public void printArgsVerb()
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