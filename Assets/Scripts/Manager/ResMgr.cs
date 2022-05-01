using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResMgr : MonoBehaviour
{
    public static ResMgr Instance;

    public void Awake()
    {
        Instance = this;
    }


    Dictionary<string, GameObject> goCacheDict = new Dictionary<string, GameObject>();

    public GameObject LoadPrefab(string path)
    {
        if (!goCacheDict.TryGetValue(path, out GameObject prefab))
        {
            prefab = Resources.Load<GameObject>(path);
            goCacheDict.Add(path, prefab);
        }

        if (prefab == null)
        {
            Debug.LogError($"创建预制体失败: {path}");
            return null;
        }

        var go = GameObject.Instantiate(prefab);
        return go;
    }
}
