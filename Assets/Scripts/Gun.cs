using System;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName =  "Gun")]
    class Gun : ScriptableObject
{
    public GameObject projectileObject;
    public AudioClip sound;
    public int numberOfSpawnPoints;
    public float rateOfFire;
}

