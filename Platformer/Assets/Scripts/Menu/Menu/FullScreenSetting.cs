using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullScreenSetting : MonoBehaviour
{
    bool isFullScreen;

    public void Start()
    {
        isFullScreen = CurrentConfig.IsFullScreen;
        gameObject.GetComponent<Toggle>().isOn = !isFullScreen;
    }

    public void FullScreenToggle()
    {
        isFullScreen = !isFullScreen;
        Screen.fullScreen = !Screen.fullScreen;
        CurrentConfig.IsFullScreen = isFullScreen;
    }
}
