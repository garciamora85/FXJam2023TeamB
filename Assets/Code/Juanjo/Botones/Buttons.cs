using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void Comenzar()
    {
        SceneManager.LoadScene("InitialCinematic");
    }

    public void Creditos()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene("Principal");
    }
    public void GoMenu()
    {
        SceneManager.LoadScene("Intro");
    }

}
