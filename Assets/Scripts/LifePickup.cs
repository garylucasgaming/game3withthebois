using System;
using System.Collections.Generic;
using UnityEngine;



class LifePickup : PickUpItem
{

    public int healthValue;
   
    public override void OnPickup(ShipModel playerShip)
    {
        playerShip.Lives = playerShip.Lives + healthValue;
    }
}

