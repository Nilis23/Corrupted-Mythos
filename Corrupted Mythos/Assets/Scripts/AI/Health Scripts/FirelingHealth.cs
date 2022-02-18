using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirelingHealth : EnemyHealth
{
    public bool inv = false;

    private void Start()
    {
        script = gameObject.GetComponent<PlayerMovement>();
    }

    public override void minusHealth(int damage, int knockback = 0)
    {
        if (!inv)
        {
            takeDamage(damage, knockback);
        }

        if (script != null)
        {
            script.killCount++;
            script.GodBarctrl.IncrementBar(script.GodBarctrl.GetFullSize() / 15);
        }
    }
}
