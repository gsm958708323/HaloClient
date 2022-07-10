using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMgr : MonoBehaviour
{
    public static AudioMgr Instance;
    AudioSource audioSource;

    public void Awake()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudio(string path, AudioSource source = null, bool isLoop = false)
    {
        if (source == null)
        {
            source = audioSource;
        }

        var clip = ResMgr.Instance.LoadAudio("ResAudio/" + path);
        source.clip = clip;
        source.loop = isLoop;
        source.Play();
    }
}
