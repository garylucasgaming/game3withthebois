using System;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PolygonCollider2D), typeof(SpriteRenderer))]
class Projectile : MonoBehaviour
{

    public int damage;
    public int speed;
    public Sprite sprite;
    private SpriteRenderer SR;
    private PolygonCollider2D projectileCollider;

    private void Awake()
    {
        SR = gameObject.GetComponent<SpriteRenderer>();
        SR.sprite = sprite;
        projectileCollider = gameObject.GetComponent<PolygonCollider2D>();
        projectileCollider.isTrigger = true;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (transform.parent.gameObject.GetComponent<EnemyController>())
        {
            if (collision.gameObject.GetComponent<EnemyController>()) return;
            if (collision.gameObject.GetComponent<PlayerController>())
            {
                collision.gameObject.GetComponent<ShipModel>().Lives--;
            }

        }
        else if (transform.parent.gameObject.GetComponent<PlayerController>())
        {
            if (collision.gameObject.GetComponent<PlayerController>()) return;
            if (collision.gameObject.GetComponent<EnemyController>() || collision.gameObject.GetComponent<Asteroid>())
            {
                if (collision.gameObject.GetComponent<ShipModel>()) { collision.gameObject.GetComponent<ShipModel>().Lives--; }
                if (collision.gameObject.GetComponent<Asteroid>()) { collision.gameObject.GetComponent<Asteroid>().lives--; }
            }
        }
    }


}
