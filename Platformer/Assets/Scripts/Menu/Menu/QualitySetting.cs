using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QualitySetting : MonoBehaviour
{
    public void Start()
    {
        QualitySettings.SetQualityLevel(CurrentConfig.Quality);
        gameObject.GetComponent<Dropdown>().value = CurrentConfig.Quality;
    }

    public void Quality(int q)
    {
        CurrentConfig.Quality = q;
        QualitySettings.SetQualityLevel(q);
    }
}
