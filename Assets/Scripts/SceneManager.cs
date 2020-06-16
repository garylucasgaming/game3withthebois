using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




    class SceneManager : MonoBehaviour
{
    private string[] _scenes = new string[] { "MainMenu", "Game","EndScreen" };
   

    public void LoadScene(String sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName, LoadSceneMode.Single);   
    }

    public void ApplicationClose()
    {
        Application.Quit();
    }
}

