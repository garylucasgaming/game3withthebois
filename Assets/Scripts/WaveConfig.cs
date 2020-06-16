using System;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "WaveConfig")]
    class WaveConfig : ScriptableObject
{

    [SerializeField] private GameObject enemyObject;
    [SerializeField] private int numberOfEnemies;
    [SerializeField] private GameObject wavePathPrefab;
    [SerializeField] private int waveSpawnSpeed;


    public GameObject GetEnemyPrefab() { return enemyObject; }

    public int GetNumberOfEnemies() { return numberOfEnemies; }

    public GameObject GetWavePathPrefab() { return wavePathPrefab; }

    public List<Transform> GetWaypoints()
    {

        var waveWaypoints = new List<Transform>();
        foreach (Transform child in wavePathPrefab.transform)
        {
            waveWaypoints.Add(child);
        }
        return waveWaypoints;

    }

    public int GetWaveSpawnSpeed() { return waveSpawnSpeed; }
}

