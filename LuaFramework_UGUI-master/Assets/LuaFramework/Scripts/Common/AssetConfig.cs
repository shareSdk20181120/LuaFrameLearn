using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetConfig
{

    public static bool UseAssetBundle
    {
        get;
        set;
    }

    public static string ResRoot
    {
        get{ return "Assets/HotResUpdate/"; }
        //set;
    }
}
