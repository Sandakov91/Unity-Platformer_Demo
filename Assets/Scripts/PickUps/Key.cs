using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : PickUp
{
    public override void AddEffect(Player player)
    {
        player.AddKey();
        base.AddEffect(player);
    }
}
