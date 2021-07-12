using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : PickUp
{
    public override void AddEffect(Player player)
    {
        player.AddDoubleJump();
        base.AddEffect(player);
    }

}
