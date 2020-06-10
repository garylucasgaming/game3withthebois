using System;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider2D))]
class Projectile : Asteroid
{



    private int damage;
    private int speed;
    private Sprite sprite;
}
