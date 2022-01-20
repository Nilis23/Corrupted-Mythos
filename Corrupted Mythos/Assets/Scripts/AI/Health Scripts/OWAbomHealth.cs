using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OWAbomHealth : EnemyHealth
{
    [SerializeField]
    float foodChance = 0.1f;
    static float chanceMod = 0;
    public GameObject foodPref;
    public int AbomPoints = 50;

    private IoDAbomHealth icon;

    private void Start()
    {
        script = gameObject.GetComponent<PlayerMovement>();
        icon = this.GetComponent<IoDAbomHealth>();
        Debug.Log(icon.gameObject.name);
    }

    public override void minusHealth(int damage, int knockback = 0)
    {
        takeDamage(damage, knockback, AbomPoints);

        if (health <= 0)
        {
            Debug.Log("Dying");
            float drop = Random.value;
            icon.dead();
            Debug.Log("Dying");
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
