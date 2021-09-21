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

            float drop = Random.value;
            Debug.Log(drop);
            if (drop == .1)
            {
                GameObject newFood = Instantiate(gameObject);
                newFood.transform.position = this.transform.position;
                newFood.transform.gameObject.AddComponent<Food>();
                newFood.transform.gameObject.AddComponent<Collider2D>();
                //add sprite
            }
        }
    }
    public void addHealth(int gain)
    {
        health += gain;
        Debug.Log(health);
    }
}
