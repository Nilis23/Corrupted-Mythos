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
    //public Transform enemy;
    private GameObject food;
    //void Update()
    //{


    //}

    public void minusHealth(int damage)
    {
        health -= damage;
        em.stagr = stagTime;
        
        if(health <= 0)
        {
            float drop = Random.value;
            if (drop <= 0.1f)
            {
                //Instead of using a new gameoject and adding new components, which uses considerable performance, consider instantiating a prefab
                GameObject food = Instantiate(foodPref);
                food.transform.position = this.transform.position;
                /*
                newFood.transform.gameObject.AddComponent<Food>();
                newFood.transform.gameObject.AddComponent<Collider2D>();
                */
                //add sprite
            }

            //this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }
    public void addHealth(int gain)
    {
        health += gain;
        Debug.Log(health);
    }
}
