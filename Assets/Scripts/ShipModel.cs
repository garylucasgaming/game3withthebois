using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
class ShipModel
{
    public Transform _transform;
    private Transform[] _projectileSpawnPoints;
    public Transform[] activeProjectileSpawnPoints;

    [SerializeField] private int _lives = 3;
    public int _maxLives = 5;
    public bool _isDead = false;

    [SerializeField] private Gun _gun;
    public bool _isFiring = false;

    public float speed = 5;
    public bool _isMoving = false;

    public int Lives
    {
        get => _lives;
        set
        {
            _lives = Mathf.Clamp(value, 0, _maxLives);
        }
    }

    public void Move(Vector2 inputDirection)
    {
        _isMoving = (inputDirection.sqrMagnitude > 0) ? true : false;
        inputDirection = inputDirection.normalized;
        _transform.position += (Vector3)(inputDirection * speed * Time.fixedDeltaTime);
    }

    public void FireGun()
    {
        foreach(GameObject spawnPoint in activeProjectileSpawnPoints)
        {
            GameObject projectile = GameObject.Instantiate(_gun.projectileObject);
        }
    }

    public void SetProjectileSpawnPoints(int numberOfSpawnPoints)
    {
        switch (numberOfSpawnPoints)
        {
            default:
            case 1:
                _activeProjectileSpawnPoints = new Transform[] {
                    _projectileSpawnPoints[0]
                };
                break;
            case 2:
                _activeProjectileSpawnPoints = new Transform[] {
                    _projectileSpawnPoints[1],
                    _projectileSpawnPoints[2]
                };
                break;
            case 3:
                _activeProjectileSpawnPoints = new Transform[] {
                    _projectileSpawnPoints[0],
                    _projectileSpawnPoints[1],
                    _projectileSpawnPoints[2]
                };
                break;
        }
    }

    public void UpdateGun(Gun gun)
    {
        _gun = gun;
        SetProjectileSpawnPoints(_gun.numberOfSpawnPoints);
    }

#if (UNITY_EDITOR)
    private void OnValidate()
    {
        Lives = _lives;
    }
#endif
}

