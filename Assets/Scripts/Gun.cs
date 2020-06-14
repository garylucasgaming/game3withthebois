using System;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Gun")]
public class Gun : ScriptableObject
{
    public GameObject projectileObject;
    public AudioClip sound;
    public int numberOfSpawnPoints;
    public float rateOfFire;
}