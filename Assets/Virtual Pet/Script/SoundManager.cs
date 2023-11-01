using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource _AudioSource;
    public void SoundClick()
    { 
        _AudioSource.Play();
    }
}
