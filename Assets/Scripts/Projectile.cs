using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

[RequireComponent(typeof(PolygonCollider2D), typeof(SpriteRenderer))]
class Projectile : MonoBehaviour
{

    public int damage;
    public int speed;
    public Sprite sprite;
    private SpriteRenderer SR;
    private PolygonCollider2D projectileCollider;
    private Rigidbody2D _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        SR = gameObject.GetComponent<SpriteRenderer>();
        SR.sprite = sprite;
        projectileCollider = gameObject.GetComponent<PolygonCollider2D>();
        projectileCollider.isTrigger = true;
        _rigidBody.velocity = Vector2.up * speed;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (transform.parent.gameObject.GetComponent<EnemyController>() != null)
        {
            if (collision.gameObject.GetComponent<EnemyController>() != null) return;
            if (collision.gameObject.GetComponent<PlayerController>() != null)
            {
                collision.gameObject.GetComponent<ShipModel>().Lives--;
            }

        }
        else if (transform.parent.gameObject.GetComponent<PlayerController>())
        {
            if (collision.gameObject.GetComponent<PlayerController>() != null) return;
            if (collision.gameObject.GetComponent<EnemyController>()  != null || collision.gameObject.GetComponent<Asteroid>() != null)
            {
                if (collision.gameObject.GetComponent<ShipModel>() != null) { collision.gameObject.GetComponent<ShipModel>().Lives--; }
                if (collision.gameObject.GetComponent<Asteroid>()  != null) { collision.gameObject.GetComponent<Asteroid>().lives--; }
            }
        }
    }


}
