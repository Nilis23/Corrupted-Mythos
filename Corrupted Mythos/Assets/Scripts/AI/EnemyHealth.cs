using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    public int health;
    [SerializeField]
    StateManager em;
    [SerializeField]
    float stagTime;
    //public Transform enemy;

    //void Update()
    //{


    //}

    public void minusHealth(int damage)
    {
        health -= damage;
        Debug.Log(health);
        em.stagr = stagTime;
        if(health <= 0)
        {
            this.gameObject.SetActive(false);

            float drop = Random.value;
            Debug.Log(drop);
            if (drop == .1)
            {
                //Instead of using a new gameoject and adding new components, which uses considerable performance, consider instantiating a prefab
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
