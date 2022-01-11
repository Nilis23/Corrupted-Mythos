using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OWFirelingHealth : EnemyHealth
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
            takeDamage(damage, knockback, 30);
        }

        if (script != null)
        {
            script.killCount++;
        }
    }
}
