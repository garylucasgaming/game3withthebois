using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

[RequireComponent(typeof(PolygonCollider2D), typeof(SpriteRenderer))]
class Projectile : MonoBehaviour
{
    private GameManager _gameManager;
    public int damage;
    public int speed;
    public Sprite sprite;
    private SpriteRenderer SR;
    private PolygonCollider2D projectileCollider;
    private Rigidbody2D _rigidBody;
    public Vector2 shootDirection;

    private void Awake()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _rigidBody = GetComponent<Rigidbody2D>();
        SR = gameObject.GetComponent<SpriteRenderer>();
        SR.sprite = sprite;
        projectileCollider = gameObject.GetComponent<PolygonCollider2D>();
        projectileCollider.isTrigger = true;
    }

    private void Start()
    {
        if (tag == "Enemy") transform.eulerAngles = new Vector3(0, 0, 180);
        _rigidBody.velocity = shootDirection * speed;
        
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (transform.parent.gameObject.GetComponent<EnemyController>() != null)
    //    {
    //        if (collision.gameObject.GetComponent<EnemyController>() != null) return;
    //        if (collision.gameObject.GetComponent<PlayerController>() != null)
    //        {
    //            collision.gameObject.GetComponent<ShipModel>().Lives--;
    //        }

    //    }
    //    else if (transform.parent.gameObject.GetComponent<PlayerController>())
    //    {
    //        if (collision.gameObject.GetComponent<PlayerController>() != null) return;
    //        if (collision.gameObject.GetComponent<EnemyController>()  != null || collision.gameObject.GetComponent<Asteroid>() != null)
    //        {
    //            if (collision.gameObject.GetComponent<ShipModel>() != null) { collision.gameObject.GetComponent<ShipModel>().Lives--; }
    //            if (collision.gameObject.GetComponent<Asteroid>()  != null) { collision.gameObject.GetComponent<Asteroid>().lives--; }
    //        }
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == this.tag) return;
        
        if (collision.GetComponent<Projectile>() == null 
            && (collision.tag == "Player" || collision.tag == "Enemy"))
        {
            var shipCollision = collision.GetComponent<ShipModel>();
            shipCollision.Lives -= damage;
            _gameManager.Score += shipCollision.killPoints;
            Destroy(gameObject);
        }
        else if (collision.tag == "Asteroid")
        {
            var asteroidCollision = collision.GetComponent<Asteroid>();
            asteroidCollision.lives -= damage;
            _gameManager.Score += asteroidCollision.killPoints;
            Destroy(gameObject);
        }
    }


}
