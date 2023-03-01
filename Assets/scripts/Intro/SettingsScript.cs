using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsScript : MonoBehaviour
{
    public AudioMixer audiomixer;
    public void SetVolume (float volume)
    {
        audiomixer.SetFloat("volume", volume);

    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
