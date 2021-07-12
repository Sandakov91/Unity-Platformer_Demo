using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : PickUp
{
    public override void AddEffect(Player player)
    {
        player.Heal();
        base.AddEffect(player);
    }
}
