using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
class ShipModel : MonoBehaviour
{
    private new Transform transform;
<<<<<<< HEAD
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
=======
    private int lives;
    private Gun gun;
    private bool isFiring;
    private bool isMoving;
    private int speed;
    private bool isDead;

    public int Lives
    {
        get => default;
>>>>>>> parent of 3b37080... incomplete gun shooting, code for setting up gun
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

