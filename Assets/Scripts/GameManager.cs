using System;
using System.Collections.Generic;
using UnityEngine;




    class GameManager : MonoBehaviour
{
    [SerializeField]
    private int score;
    private SceneManager sceneManager;
    private WaveManager waveManager;

    public int Score
    {
        get => score; 
        set
        {
            score = value;
        }
    }

    public void GetManagers()
    {
        throw new System.NotImplementedException();
    }


    private void Awake()
    {
        Time.timeScale = 1; 
    }
}

