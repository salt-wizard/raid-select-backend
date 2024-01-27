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
     * **/


    public string ObjToString(object obj)
    {
        return JsonConvert.SerializeObject(obj, Formatting.Indented, new JsonConverter[] { new StringEnumConverter() });
    }
}
/************************************************************************
* COPY AND PASTE ABOVE CLASS INTO STREAMER.BOT
* DO NOT COPY ANYTHING OUTSIDE THE BLOCK COMMENT
************************************************************************/
#pragma warning restore CA1822, CA1050