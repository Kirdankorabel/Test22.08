using System.Collections.Generic;
using UnityEngine;

public static class StaticInfo
{
    public static Date date;
    public static readonly string path = Application.streamingAssetsPath + "/";
    public static readonly string manifestName = "StreamingAssets";
    public static readonly List<string> paths = new List<string>
    {
        "images",
        "musics",
        "icons",
        "sounds",
        "textures"
    };

    public static IStateSaver<VertPanelInfo> VerticalPanel { get; set; }
    public static IStateSaver<SettingsInfo> AudioSettingsPanel { get; set; }
    public static float ScaleFactor => Screen.height / 800f;
    public static SoundManager SoundManager { get; set; }
}