using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSetting : MonoBehaviour
{
    public Slider VolumeSlider;

    public void Update()
    {
        AudioListener.volume = VolumeSlider.value;
    }
}
