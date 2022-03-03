using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonerHealth : EnemyHealth
{
    public override void minusHealth(int damage, int knockback = 0)
    {
        takeDamage(damage, knockback);
    }
}
