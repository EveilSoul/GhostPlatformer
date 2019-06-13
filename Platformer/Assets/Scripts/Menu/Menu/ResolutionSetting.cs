using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class ResolutionSetting : MonoBehaviour
{
    Resolution[] resolutions;
    List<string> resolDescr;

    public void Start()
    {
        resolutions = Screen.resolutions;
        resolDescr = new List<string>();

        foreach (var e in resolutions)
        {
            resolDescr.Add(e.width + "x" + e.height);
        }

        var ResolutinDropdown = gameObject.GetComponent<Dropdown>();
        ResolutinDropdown.ClearOptions();
        ResolutinDropdown.AddOptions(resolDescr);


        Resolution(CurrentConfig.Resolution);
        ResolutinDropdown.value = CurrentConfig.Resolution;
    }

    public void Resolution(int res)
    {
        CurrentConfig.Resolution = res;
        Screen.SetResolution(resolutions[res].width, resolutions[res].height, Screen.fullScreen);
    }
}
