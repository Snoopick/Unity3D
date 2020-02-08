using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatBonus : Bonus
{
    protected override void PickUpBonus()
    {
        base.PickUpBonus();
        
        //TODO
        var player = FindObjectOfType<PlayerController>();
        player.WearHat();
    }

}
