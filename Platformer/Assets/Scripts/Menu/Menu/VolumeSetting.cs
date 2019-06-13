using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSetting : MonoBehaviour
{
    Slider VolumeSlider;

    public void Start()
    {
        VolumeSlider = gameObject.GetComponent<Slider>();
        VolumeSlider.value = CurrentConfig.Volume;
    }

    public void VolumePressed()
    {
        CurrentConfig.Volume = VolumeSlider.value;
        AudioListener.volume = VolumeSlider.value;
    }
}
