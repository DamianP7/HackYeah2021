using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Music : Singleton<Music>
{
    bool music = true;
    [SerializeField]
    AudioSource audioSource;

    private void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    public void Toggle()
    {
        music = !music;
        audioSource.mute = !music;
    }

}
