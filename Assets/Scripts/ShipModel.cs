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
    public bool isFiring = false;

    public float speed = 5;
    public bool isMoving = false;

    public int killPoints = 1;

    private IEnumerator FireProjectile(Vector2 newShootDirection)
    {
        isFiring = true;
        foreach (Transform spawnPoint in activeProjectileSpawnPoints)
        {
            GameObject projectile = GameObject.Instantiate(
                gun.projectileObject,
                spawnPoint.position,
                Quaternion.identity);
            projectile.tag = this.tag;
            projectile.GetComponent<Projectile>().shootDirection = newShootDirection;
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
            if (_lives == 0) isDead = true;
        }
    }

    public void Move(Vector2 inputDirection)
    {
        isMoving = (inputDirection.sqrMagnitude > 0) ? true : false;
        inputDirection = inputDirection.normalized;
        transform.position += (Vector3)(inputDirection * speed * Time.fixedDeltaTime);
    }

    public void FireGun(Vector2 newShootDirection)
    {
        print("firing gun");
        if (!isFiring) StartCoroutine(FireProjectile(newShootDirection));
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
        SetProjectileSpawnPoints(gun.numberOfSpawnPoints);
    }

    public void OnDeath(float delay)
    {
        Destroy(gameObject, delay);
    }

#if (UNITY_EDITOR)
    private void OnValidate()
    {
        Lives = _lives;
    }
#endif
}

