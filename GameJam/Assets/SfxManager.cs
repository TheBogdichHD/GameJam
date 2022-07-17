using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManager : MonoBehaviour
{
    public AudioSource Audio;

    public AudioClip move_1;
    public AudioClip move_2;
    public AudioClip enemyFought;
    public AudioClip death;
    public AudioClip fenceDown;
    public AudioClip mud;
    public AudioClip sceneLoad;

    public static SfxManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this);
    }
}
