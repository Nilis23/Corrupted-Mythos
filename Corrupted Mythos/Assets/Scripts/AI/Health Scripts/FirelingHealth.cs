using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirelingHealth : EnemyHealth
{
    bool inv = false;

    public override void minusHealth(int damage, int knockback = 0)
    {
        if (!inv)
        {
            takeDamage(damage, knockback);
        }
    }
}
