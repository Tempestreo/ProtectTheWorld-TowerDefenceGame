using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class sliderscript : MonoBehaviour
{
    public Slider sl;
    public AudioMixer audiomixer;
    float volume;
    void Start()
    {

        audiomixer.GetFloat("volume", out volume);
        sl.value = volume;
    }
}
