using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class ResolutionSetting : MonoBehaviour
{
    Resolution[] resolutions;
    List<string> resolDescr;
    public Dropdown ResolutinDropdown;

    public void Awake()
    {
        resolutions = Screen.resolutions;
        resolDescr = new List<string>();

        foreach (var e in resolutions)
        {
            resolDescr.Add(e.width + "x" + e.height);
        }
        ResolutinDropdown.ClearOptions();
        ResolutinDropdown.AddOptions(resolDescr);

        Screen.SetResolution(resolutions[resolutions.Length - 1].height, resolutions[resolutions.Length - 1].width, Screen.fullScreen);
        ResolutinDropdown.value = resolutions.Length - 1;
    }

    public void Resolution(int res)
    {
        Debug.Log(res);
        Screen.SetResolution(resolutions[res].width, resolutions[res].height, Screen.fullScreen);
    }
}
