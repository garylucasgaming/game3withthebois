using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



class WaveManager : MonoBehaviour
{

    [SerializeField] private int wavesCompleted;
    [SerializeField] private List<WaveConfig> easyWaveList;
    [SerializeField] private List<WaveConfig> mediumWaveList;
    [SerializeField] private List<WaveConfig> hardWaveList;

    [SerializeField] private int currentWaveIndex = 0;

    [SerializeField] private bool looping = false;



    private List<WaveConfig> currentWaveList;

    private void Awake()
    {
        currentWaveList = easyWaveList;

    }

    private IEnumerator Start()
    {

        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (looping);
        
    }


    private void Update()
    {
        
        

      
    }

    private IEnumerator SpawnAllWaves()
    {
        

        for (int i = currentWaveIndex; i < currentWaveList.Count; i++)
        {
            var currentWave = currentWaveList[i];

            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));

        }

    }


    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        for (int i = 0; i  < waveConfig.GetNumberOfEnemies(); i++)
        {
            var newEnemy = Instantiate(waveConfig.GetEnemyPrefab(), waveConfig.GetWaypoints()[0].transform.position, Quaternion.identity);
            newEnemy.GetComponent<ICanPath>().SetPath(waveConfig.GetWaypoints());
            yield return new WaitForSeconds(waveConfig.GetWaveSpawnSpeed());
        }
      
    }


    //TODO  add difficulty update
    public void updateDifficulty()
    {
        
    }
}

