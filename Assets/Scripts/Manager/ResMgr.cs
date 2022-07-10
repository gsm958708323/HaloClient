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
    Dictionary<string, AudioClip> aduioCacheDict = new Dictionary<string, AudioClip>();

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

    public AudioClip LoadAudio(string path)
    {
        if (!aduioCacheDict.TryGetValue(path, out AudioClip prefab))
        {
            prefab = Resources.Load<AudioClip>(path);
            aduioCacheDict.Add(path, prefab);
        }

        if (prefab == null)
        {
            Debug.LogError($"创建声音失败: {path}");
            return null;
        }

        return prefab;
    }
}
