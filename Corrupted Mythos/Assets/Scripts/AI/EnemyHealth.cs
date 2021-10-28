using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    public int health;
    public GameObject foodPref;
    [SerializeField]
    StateManager em;
    [SerializeField]
    float stagTime;
    [SerializeField]
    float foodChance = 0.1f;
    [Space]
    [SerializeField]
    Animator animator;

    static float chanceMod = 0;

    public void minusHealth(int damage, bool knockback)
    {
        health -= damage;
        em.setStgr(stagTime, true);
        animator.SetTrigger("Hit");
        if (knockback)
        {
            em.knockback();
        }

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

            Destroy(this.gameObject, 0.1f);
        }

    }
    public void addHealth(int gain)
    {
        health += gain;
        Debug.Log(health);
    }
}
