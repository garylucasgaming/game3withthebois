using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
class ShipModel : MonoBehaviour
{
    private new Transform transform;
    [SerializeField]
    private int lives;
    public Gun gun;
    public bool isFiring;
    public bool isMoving;
    public int speed;
    public bool isDead;

    public int Lives
    {
        get => lives;
        set
        {
        }
    }

    public void Move(Vector2  inputDirection)
    {
        
    }

    public void GunFire()
    {
        throw new System.NotImplementedException();
    }

    public void GenerateProjectileSpawnPoints()
    {
        throw new System.NotImplementedException();
    }

    public void UpdateGun()
    {
        throw new System.NotImplementedException();
    }
}

