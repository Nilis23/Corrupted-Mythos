using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    public int health;
    public GameObject foodPref;
    //[SerializeField]
    //bool inv;
    [Space]
    [SerializeField]
    StateManager em;
    [SerializeField]
    float stagTime;
    [SerializeField]
    float foodChance = 0.1f;
    [Space]
    [SerializeField]
    Animator animator;
    public PlayerMovement script;

    static float chanceMod = 0;

    public void minusHealth(int damage, int knockback = 0)
    {
        //if (!inv) //Also obsolesced
        //{
            health -= damage;
            em.setStgr(stagTime, true);
            animator.SetTrigger("Hit");
            if (knockback == 1)
            {
                em.knockback();
            }
            else if (knockback == 2)
            {
                em.KnockUp();
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

                //script.killCount++;
                Destroy(this.gameObject, 0.1f);
            //}
            /* obsolesced code - will be replaced with new inhertiance based health class
            else if()
            {

            }
            */
        }
    }

    public void addHealth(int gain)
    {
        health += gain;
        Debug.Log(health);
    }
}
