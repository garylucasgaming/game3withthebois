using System;
using System.Collections.Generic;
using UnityEngine;



class Asteroid : MonoBehaviour, ICanPath
{
    [SerializeField]private int damage;
    [SerializeField]private int speed;
    private int sprite;
    [SerializeField] public int lives;
    private int waypointIndex = 0;
    [SerializeField] public List<Transform> path;

    private void Start()
    {
        transform.position  = new Vector3(path[waypointIndex].position.x, path[waypointIndex].position.y, 0);
    }

    private void Update()
    {
       MoveAlongPath();
        transform.Rotate(0, 0, 180 * Time.deltaTime);
    }

    public void MoveAlongPath()
    {
        if (waypointIndex <= path.Count - 1)
        {
            var targetPosition = new Vector3(path[waypointIndex].position.x, path[waypointIndex].position.y, 0);


            transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);

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

    public void SetPath(List<Transform> newPath) {
        path = newPath;
    }

    public void OnDeath()
    {
        Destroy(gameObject);
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<ShipModel>().Lives--;
            OnDeath();

        }
    }

}

