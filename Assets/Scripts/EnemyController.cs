using System;
using System.Collections.Generic;
using UnityEngine;



class EnemyController : MonoBehaviour, ICanPath
{
    private ShipModel shipModel;
    public List<Transform> path;
    private int waypointIndex = 0;

    private void Awake()
    {
        shipModel = gameObject.GetComponent<ShipModel>();
      
    }

  
    private void Update()
    {

       
            MoveAlongPath();
        
    }

    public void OnDeath()
    {
       
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

    public void SetPath(List<Transform> newPath)
    {
        path = newPath;
    }

}

