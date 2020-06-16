using System;
using System.Collections.Generic;
using UnityEngine;



class PickUpItem :  MonoBehaviour
{

    public virtual void OnPickup(ShipModel playerShip)
    {

    }

    private void OnTriggerEnter2D(Collider2D ship)
    {
        if(ship.tag == "Player")
        {
            OnPickup(ship.GetComponent<ShipModel>());
        }
    }

    private void Update()
    {
        transform.Translate(Vector2.down * 0.8f * Time.deltaTime);
    }

}

