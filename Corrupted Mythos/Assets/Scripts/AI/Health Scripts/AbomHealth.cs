using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbomHealth : EnemyHealth
{
    [SerializeField]
    float foodChance = 0.1f;
    static float chanceMod = 0;
    public GameObject foodPref;

    private void Start()
    {
        script = gameObject.GetComponent<PlayerMovement>();
    }

    public override void minusHealth(int damage, int knockback = 0)
    {
        takeDamage(damage, knockback);

        if (health <= 0)
        {
            float drop = Random.value;
            if (drop <= (foodChance + chanceMod))
            {
                GameObject food = Instantiate(foodPref);
                food.transform.position = this.transform.position;
                chanceMod = 0;
            }
            else
            {
                chanceMod += 0.05f;
            }

            if (script != null)
            {
                script.killCount++;
            }
        }
    }
}
