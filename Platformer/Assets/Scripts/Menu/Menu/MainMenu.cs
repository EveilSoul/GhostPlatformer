using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Canvas Canvas;

    public void StartPressed()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitPressed()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
