using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingPoint : ShootingPoint
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            Shoot();
        } 
        Reload();
    }
}
