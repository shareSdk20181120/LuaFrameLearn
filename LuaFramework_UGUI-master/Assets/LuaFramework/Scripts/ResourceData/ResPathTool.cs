using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResPathTool
{

    public static string GetPath(EnumAssetType type)
    {
        string path = AssetConfig.ResRoot;
        switch(type)
        {
            case EnumAssetType.Default:
                return path;
            case EnumAssetType.UIPrefab:
                return path + "UGUI/Prefab/";
        }

        return string.Empty;
    }
       
}
