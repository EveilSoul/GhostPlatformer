using System.Collections.Generic;

static class CurrentConfig
{
    public static bool IsInitialize { get; private set; }

    public static int Level { get; set; }
    public static bool IsFullScreen { get; set; }
    public static int Resolution { get; set; }
    public static int Quality { get; set; }
    public static float Volume { get; set; }

    public static string FileName = "CurrentConfig";

    public static void Awake()
    {
        
        var config=Ini.Load(FileName);

        
        if (config == null)
        {
            IsInitialize = false;
            return;
        }
        IsInitialize = true;
            

        Level = int.Parse(config["Level"]);
        IsFullScreen = bool.Parse(config["IsFullScreen"]);
        Resolution= int.Parse(config["Resolution"]);
        Quality= int.Parse(config["Quality"]); 
        Volume= float.Parse(config["Volume"]);
    }

    public static void OnQuit()
    {
        var config = new Dictionary<string, string>();
        config["Level"] = Level.ToString();
        config["IsFullScreen"] = IsFullScreen.ToString();
        config["Volume"] = Volume.ToString();
        config["Quality"] = Quality.ToString();
        config["Resolution"] = Resolution.ToString();
        Ini.Save(FileName, config);
    }
}

