using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
class ShipModel : MonoBehaviour
{
    private new Transform transform;
    [SerializeField]
    private int lives;
    private Gun gun;
    private bool isFiring;
    private bool isMoving;
    public int speed;
    private bool isDead;

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

