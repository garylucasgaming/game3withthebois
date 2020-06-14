using System;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName =  "Gun")]
    public class Gun : ScriptableObject
{
    public Sprite projectileObject;
    public int sound;
    public int numberOfSpawnPoints;
    public int rateOfFire;
}

