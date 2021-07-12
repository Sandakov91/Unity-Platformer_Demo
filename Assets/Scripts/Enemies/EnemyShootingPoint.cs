using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootingPoint : ShootingPoint
{
    private Player target;
    void Update()
    {
        if (target && canShoot)
        {
            ShootOnTarget(target);
        }
        Reload();
    }
    public void SetTarget (Player player)
    {
        target = player;
    }
}
