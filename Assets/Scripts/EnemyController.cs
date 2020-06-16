using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



class EnemyController : MonoBehaviour, ICanPath
{
    private ShipModel shipModel;
    public List<Transform> path;
    private int waypointIndex = 0;
    private ShipView shipView;
    public Gun initialGun;

    private void Awake()
    {
        shipView = gameObject.GetComponent<ShipView>();
        shipModel = gameObject.GetComponent<ShipModel>();
        shipModel.projectileSpawnPoints = new Transform[]
        {
            transform.GetChild(0),
            transform.GetChild(1),
            transform.GetChild(2)
        };
    }

    private void Start()
    {
        shipModel.UpdateGun(initialGun);
    }

    private void Update()
    {
        if (!shipModel.isDead)
        {
            MoveAlongPath();
            FireGun();
        }
        if (shipModel.isDead) OnDeath();
    }

    public void FireGun()
    {
        shipView.OnFire();
        shipModel.FireGun(Vector2.down);
    }


    private IEnumerator EnemyFireCoroutine(float waitTime)
    {

        FireGun();

        yield return new WaitForSeconds(waitTime);

    }

  

    public void OnDeath()
    {
        shipView.OnDeath();
    }

    public void MoveAlongPath()
    {

        if (waypointIndex <= path.Count - 1)
        {
            var targetPosition = new Vector3(path[waypointIndex].position.x, path[waypointIndex].position.y, 0);

        
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * shipModel.speed);

            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
           
           
        }
        
     

        
    }

    private IEnumerator DeathCoroutine()
    {
        yield return new WaitForSeconds(.5f);

        Destroy(gameObject);
    }

    public void SetPath(List<Transform> newPath)
    {
        path = newPath;
    }

}

