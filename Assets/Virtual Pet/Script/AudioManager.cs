using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource[] music;
    //public AudioSource[] sfx;
    public AudioSource src;
    public AudioClip soundeat1, soundeat2;

    public void ButtonEat()
    {
        src.clip = soundeat1;
        src.Play();
    }

   private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        //PlayMusic(0); 
    }

    void Update()
    {
      if(Input.GetKeyDown(KeyCode.M))
        {
           
        }
                
    }

    /*public void PlayMusic(int musicToPlay)
    {
        for (int i = 0; i < music.Length; i++)
        {
            music[i].Stop();
        }
        music[musicToPlay].Play();
    }

    public void PlaySFX(int sfxToPlay)
    {
        sfx[sfxToPlay].Play();
    }*/


}
