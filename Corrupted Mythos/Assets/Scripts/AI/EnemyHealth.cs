using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    public int health;
    public GameObject foodPref;
    [Space]
    [SerializeField]
    StateManager em;
    [SerializeField]
    float stagTime;
    
    [Space]
    [SerializeField]
    Animator animator;
    public PlayerMovement script;

    //MinusHealth is now an abstract funtion implemented by individual enemy health scripts, this makes it easier for each enemy to do something different
    public abstract void minusHealth(int damage, int knockback = 0);

    public void takeDamage(int damage, int knockback = 0)
    {
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
            
            Destroy(this.gameObject, 0.1f);
        }
    }

    public void addHealth(int gain)
    {
        health += gain;
        Debug.Log(health);
    }
}
