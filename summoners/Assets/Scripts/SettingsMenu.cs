using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Audio;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer mainMixer;
    public void FullscreenToggle(bool toggle)
    {
        Screen.fullScreen = toggle;
    }

    public void SetQuality(int quality)
    {
        QualitySettings.SetQualityLevel(quality);
    }

    public void SetVolume (float volume)
    {
        mainMixer.SetFloat("volume", volume);
    }
}
