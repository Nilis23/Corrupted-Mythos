using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    public int health;
    //public Transform enemy;

    //void Update()
    //{
        /** -- Rather than using CPU time every frame, this could instead be called when the enemy is damaged to see if the enemy should die
        if (health<=0)
        {
            enemy.gameObject.SetActive(false);
        }
        **/
    //}

    public void minusHealth(int damage)
    {
        health -= damage;
        Debug.Log(health);
        if(health <= 0)
        {
            this.gameObject.SetActive(false);
            //Destroy(this);
        }
    }
    public void addHealth(int gain)
    {
        health += gain;
        Debug.Log(health);
    }
}
