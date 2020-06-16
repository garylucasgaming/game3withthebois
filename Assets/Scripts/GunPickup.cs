using System;
using System.Collections.Generic;
using UnityEngine;



class GunPickup : PickUpItem
{
    public Gun gun;

    public override void OnPickup(ShipModel playerShip)
    {
     //   playerShip.UpdateGun(gun);
    }
}

