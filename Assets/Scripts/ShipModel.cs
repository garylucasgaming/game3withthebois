using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

class ShipModel : MonoBehaviour
{
    public new Transform transform;
    public Transform[] projectileSpawnPoints;
    public Transform[] activeProjectileSpawnPoints;

    [SerializeField] private int _lives = 3;
    public int maxLives = 5;
    public bool isDead = false;

    public Gun gun;
    private Projectile _gunProjectile;
    public bool isFiring = false;

    public float speed = 5;
    public bool isMoving = false;

    private void Start()
    {
        
    }

    private IEnumerator FireProjectile()
    {
        isFiring = true;
        foreach (Transform spawnPoint in activeProjectileSpawnPoints)
        {
            GameObject projectile = GameObject.Instantiate(
                gun.projectileObject,
                spawnPoint.position,
                Quaternion.identity, transform);
        }
        yield return new WaitForSeconds(gun.rateOfFire);
        isFiring = false;
    }
    public int Lives
    {
        get => _lives;
        set
        {
            _lives = Mathf.Clamp(value, 0, maxLives);
        }
    }

    public void Move(Vector2 inputDirection)
    {
        isMoving = (inputDirection.sqrMagnitude > 0) ? true : false;
        inputDirection = inputDirection.normalized;
        transform.position += (Vector3)(inputDirection * speed * Time.fixedDeltaTime);
    }

    public void FireGun()
    {
        if (!isFiring) StartCoroutine(FireProjectile());
    }

    public void SetProjectileSpawnPoints(int numberOfSpawnPoints)
    {
        switch (numberOfSpawnPoints)
        {
            default:
            case 1:
                activeProjectileSpawnPoints = new Transform[] {
                    projectileSpawnPoints[0]
                };
                break;
            case 2:
                activeProjectileSpawnPoints = new Transform[] {
                    projectileSpawnPoints[1],
                    projectileSpawnPoints[2]
                };
                break;
            case 3:
                activeProjectileSpawnPoints = new Transform[] {
                    projectileSpawnPoints[0],
                    projectileSpawnPoints[1],
                    projectileSpawnPoints[2]
                };
                break;
        }
    }

    public void UpdateGun(Gun gun)
    {
        gun = gun;
        _gunProjectile = gun.projectileObject.GetComponent<Projectile>();
        SetProjectileSpawnPoints(gun.numberOfSpawnPoints);
    }

#if (UNITY_EDITOR)
    private void OnValidate()
    {
        Lives = _lives;
    }
#endif
}

