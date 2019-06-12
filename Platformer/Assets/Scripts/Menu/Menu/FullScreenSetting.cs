using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullScreenSetting : MonoBehaviour
{
    bool isFullScreen;

    public void Awake()
    {
        isFullScreen = Screen.fullScreen;
    }

    public void FullScreenToggle()
    {
        isFullScreen = !isFullScreen;
        Screen.fullScreen = isFullScreen;
    }
}
