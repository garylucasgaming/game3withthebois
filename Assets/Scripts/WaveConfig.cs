using System;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "WaveConfig")]
    class WaveConfig : ScriptableObject
{
    private GameObject enemyObjects;
    private int numberOfEnemies;
    private Transform[] wavePath;
    private int waveSpawnSpeed;
}

