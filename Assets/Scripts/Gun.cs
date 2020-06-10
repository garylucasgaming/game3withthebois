using System;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName =  "Gun")]
    class Gun : ScriptableObject
{
    private Sprite projectileObject;
    private int sound;
    private int numberOfSpawnPoints;
    private int rateOfFire;
}

