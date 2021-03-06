using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OWFirelingHealth : EnemyHealth
{
    public bool inv = false;
    private int points = 30;

    private void Start()
    {
        script = gameObject.GetComponent<PlayerMovement>();
    }

    public override void minusHealth(int damage, int knockback = 0)
    {
        if (!inv)
        {
            takeDamage(damage, knockback, points);
        }

        if (script != null)
        {
            script.killCount++;
            script.GodBarctrl.IncrementBar(script.GodBarctrl.GetFullSize() / 15);
        }
    }
}
