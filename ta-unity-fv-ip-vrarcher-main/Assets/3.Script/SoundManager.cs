using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;
    public GameObject BGMManager;
    public GameObject SFXManager;
    public GameObject test;
    public AudioSource Bgm;
    public AudioSource[] SFX;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        Bgm = BGMManager.GetComponent<AudioSource>();
        SFX = SFXManager.GetComponents<AudioSource>();
    }
    public void BGMSetting(bool set)
    {
        if (set)
        {
            Bgm.Play();
        }
        else
        {
            Bgm.Stop();
        }
    }
    public void PlaySFXSound(AudioClip clip)
    {
        for(int i =0;i<SFX.Length;i++)
        {
            if(!SFX[i].isPlaying)
            {
                SFX[i].clip = clip;
                SFX[i].Play();
                break;
            }
        }
    }
}
