using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceOrb : Item
{
    public int expValue;
    public override void PickUp()
    {
        Player.instance.playerExp += expValue;
        Player.instance.ExperienceCheck();
        base.PickUp();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 3)
        {
            PickUp();
        }
    }
}
