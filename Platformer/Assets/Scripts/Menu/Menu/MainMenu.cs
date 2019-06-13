using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Canvas Canvas;

    public void StartPressed()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
    }

    public void ContinuePressed()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    public void QuitPressed()
    {
        CurrentConfig.OnQuit();
        Application.Quit();
    }
}
