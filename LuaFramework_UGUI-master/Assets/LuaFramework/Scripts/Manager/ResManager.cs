using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class ResManager
    {

        private static Object LoadAsset(string path, System.Type type, string ext, EnumAssetType assetType = EnumAssetType.Default, System.Action<Object> callBack = null)
        {
            string tempPath = ResPathTool.GetPath(assetType);
            if (string.IsNullOrEmpty(tempPath))//完整路径
                tempPath = path;
            else
                tempPath += path;
            Object obj = ResourceVessel.LoadAsset(tempPath, type, ext, callBack);
            return obj;
        }

        private static Object LoadAsset(string path, System.Type type, string ext, EnumAssetType assetType = EnumAssetType.Default, LuaInterface.LuaFunction callBack = null)
        {
            string tempPath = ResPathTool.GetPath(assetType);
            if (string.IsNullOrEmpty(tempPath))//完整路径
                tempPath = path;
            else
                tempPath += path;
            Object obj = ResourceVessel.LoadAsset(tempPath, type, ext, callBack);
            return obj;
        }

        public static GameObject LoadPrefab(string path, EnumAssetType assetType, System.Action<Object> callBack)
        {
            GameObject obj = LoadAsset(path, typeof(GameObject), ".prefab", assetType, callBack) as GameObject;
            if (obj == null)
            {
                Debug.LogError("load prefab is null --path: " + path);

            }
            return obj;
        }

        public static GameObject LoadPrefab(string path, EnumAssetType assetType,LuaInterface.LuaFunction  callBack)
        {
            GameObject obj = LoadAsset(path, typeof(GameObject), ".prefab", assetType, callBack) as GameObject;
            if (obj == null)
            {
                Debug.LogError("load prefab is null --path: " + path);

            }
            else
            {
                GameObject go = GameObject.Instantiate(obj);
                go.name = path;
                return go;
            }
            return obj;
        }

        public static Sprite LoadSprite(string path, EnumAssetType assetType, System.Action<Object> callBack)
        {
            Sprite sp = LoadAsset(path, typeof(Sprite), ".png", assetType, callBack) as Sprite;
            return sp;
        }

    }
}
