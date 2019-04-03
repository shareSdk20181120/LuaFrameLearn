using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uobject = UnityEngine.Object;
using SObject = System.Object;
using UnityEditor;

public class ResourceVessel
{

    //资源集合
    private static Dictionary<string, Uobject> assetObjDic = new Dictionary<string, Uobject>();
    private static Dictionary<string, int> assetNumDic = new Dictionary<string, int>();

   
    public static Uobject LoadAsset(string path,System.Type type,string ext,System.Action<Uobject> callBack=null)
    {
        Uobject obj = null;
        if (assetObjDic.TryGetValue(path, out obj))
        {
            assetNumDic[path]++;
            if (callBack != null)
                callBack(obj);

            return obj;
        }

        if(AssetConfig.UseAssetBundle)
        {

        }
        else
        {
#if UNITY_EDITOR
            obj = AssetDatabase.LoadAssetAtPath(path+ext, type);
            if (obj == null && ext == ".png")
            {
                Debug.LogError("load png-->jpg");
                obj = AssetDatabase.LoadAssetAtPath(path + ".jpg", type);
            }
#endif
        }
        if (obj)
        {
            assetNumDic.Add(path, 1);
            assetObjDic.Add(path, obj);
            if (callBack != null)
                callBack(obj);
        }
        else
        {
            Debug.LogError("load asset fail  ---path: " + path);
        }
        return obj;
    }

    public static Uobject LoadAsset(string path, System.Type type, string ext, LuaInterface.LuaFunction callBack = null)
    {
        Uobject obj = null;
        if (assetObjDic.TryGetValue(path, out obj))
        {
            assetNumDic[path]++;
            if (callBack != null)
                callBack.Call(obj);

            return obj;
        }

        if (AssetConfig.UseAssetBundle)
        {

        }
        else
        {
#if UNITY_EDITOR
            obj = AssetDatabase.LoadAssetAtPath( path + ext, type);
            if (obj == null && ext == ".png")
            {
                Debug.LogError("load png-->jpg");
                obj = AssetDatabase.LoadAssetAtPath( path + ".jpg", type);
            }
#endif
        }
        if (obj)
        {
            assetNumDic.Add(path, 1);
            assetObjDic.Add(path, obj);
            if (callBack != null)
                callBack.Call(obj);
        }
        else
        {
            Debug.LogError("load asset fail  ---path: " + path);
        }
        return obj;
    }


    public static void UnLoadAsset(string path,bool unloadAll)
    {
        if(assetNumDic==null || !assetNumDic.ContainsKey(path))
        {
            return;
        }
        assetNumDic[path]--;
        if(assetNumDic[path]<=0)
        {
            if(AssetConfig.UseAssetBundle)
            {

            }
            else
            {
                Uobject obj = null;
                if(assetObjDic.TryGetValue(path,out obj))
                {
                    if(!(obj is GameObject))
                    {
                        Debug.LogError("path " + path);
                        Resources.UnloadAsset(obj);
                    }

                    assetNumDic.Remove(path);
                    assetObjDic.Remove(path);
                }
            }
        }
    }

    public static void UnLoadAllAsset()
    {
        if(AssetConfig.UseAssetBundle)
        {

        }
        else
        {
            var ie = assetObjDic.GetEnumerator();
            while(ie.MoveNext())
            {
                Uobject m = ie.Current.Value;
                if (!(m is GameObject))
                {
                    Resources.UnloadAsset(m);
                }
            }
            ie.Dispose();
            
        }

        assetObjDic.Clear();
        assetNumDic.Clear();
    }

  

}
