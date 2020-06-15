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

    private void Awake()
    {
        shipModel = gameObject.GetComponent<ShipModel>();
        shipView = gameObject.GetComponent<ShipView>();
    }

    private IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(EnemyFireCoroutine(shipModel.gun.rateOfFire));
        }
        while (!shipModel.isDead);
    }

    private void Update()
    {
        MoveAlongPath();
     
    }

    public void GunFire()
    {
        shipView.OnFire();
        //shipModel.GunFire();
        Debug.Log(message: "isShooting", context: gameObject);
       
    }


    private IEnumerator EnemyFireCoroutine(float waitTime)
    {

        GunFire();

        yield return new WaitForSeconds(waitTime);

    }

  

    public void OnDeath()
    {
        shipModel.isDead = true;
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
            if (!shipModel.isDead) { print("on death"); shipModel.isDead = true; OnDeath();  }
           
           
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

