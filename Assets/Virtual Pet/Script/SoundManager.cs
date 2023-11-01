using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource _AudioSource;
    public void SoundClick()
    { 
        _AudioSource.Play();
    }
    public void Sound()
    {
        if( _AudioSource.mute)
        {
            _AudioSource.mute = false;
        }
        else
        {
            _AudioSource.mute = true;
        }
    }
    public void Music()
    {
        if (_AudioSource.mute)
        {
            _AudioSource.mute = false;
        }
        else
        {
            _AudioSource.mute = true;
        }
    }
}
