using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    public int health;
    [Space]
    [SerializeField]
    public StateManager em;
    [SerializeField]
    float stagTime;
    
    [Space]
    [SerializeField]
    public Animator animator;
    public PlayerMovement script;
    public GameObject player;
    [SerializeField]
    public GameObject soulPref;

    //private IoDAbomHealth icon;

    //MinusHealth is now an abstract funtion implemented by individual enemy health scripts, this makes it easier for each enemy to do something different
    public abstract void minusHealth(int damage, int knockback = 0);

    public void takeDamage(int damage, int knockback = 0, int points =0)
    {
        health -= damage;
        animator.SetTrigger("Hit");
        if(knockback == 0)
        {
            em.setStgr(stagTime, true);
        }
        else if (knockback == 1)
        {
            em.knockback(1f);
            em.setStgr(stagTime, true);
        }
        else if (knockback == 2)
        {
            em.KnockUp();
            em.setStgr(stagTime, true);
        }
        else if(knockback == 10)
        {
            em.knockback(4f);
            em.setStgr(20, true);

        }

        if (health <= 0)
        {
            if (points != 0)
            {
                player.GetComponent<PlayerHealth>().points += points;
                Debug.Log("adding points: enemy "+points);
                if (player.GetComponent<PlayerHealth>().pointScore != null)
                    player.GetComponent<PlayerHealth>().pointScore.text = player.GetComponent<PlayerHealth>().pointScore.ToString();

            }

            /*
            soulPref.GetComponent<wispParticles>().player = player;
            Debug.Log(soulPref);
            GameObject Soul = Instantiate(soulPref);
            Soul.transform.position = this.transform.position;
            Soul.transform.parent = null;
            Soul.SetActive(true);
            */
            Destroy(this.gameObject, 0.1f);            
        }
    }

    public void addHealth(int gain)
    {
        health += gain;
        Debug.Log(health);
    }
}
