using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health, check=0;
    public Transform player;
    public Transform spawn;
    public GameObject death;
    public Slider hpBar;

    private void Start()
    {
        hpBar.maxValue = health;
        hpBar.value = health;
    }

    /*
    void Update()
    {
        if (health <= 0)
        {
            player.position = spawn.position;
            health = 100;
        }
    }
    */

    public void minusHealth(int damage)
    {
        health -= damage;
        Debug.Log(health);
        //update UI
        hpBar.value = health;

        //For now we delete the player;
        if (health <= 0)
        {
            death.SetActive(true);
            Destroy(this.gameObject);
        }
        /* respawn script
        if (health <= 0)
        {
            player.position = spawn.position;
            health = 100;
        }
        */
    }
    public void addHealth(int gain)
    {
        health += gain;
        Debug.Log(health);
        //update UI
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("checkpoint"))
        {
            Debug.Log("checkpoint");
            spawn.position = other.transform.position;
            check += 1;
            Destroy(other);
        }
    }
}
