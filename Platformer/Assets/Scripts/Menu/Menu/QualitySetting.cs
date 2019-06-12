using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QualitySetting : MonoBehaviour
{
    public void Awake()
    {
        QualitySettings.SetQualityLevel(3);
    }

    public void Quality(int q)
    {
        Debug.Log(q);
        QualitySettings.SetQualityLevel(q);
    }
}
