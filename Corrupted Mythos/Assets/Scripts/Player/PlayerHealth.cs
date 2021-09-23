using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health, check=0, maxHealth;
    public Transform player;
    public Transform spawn;
    public GameObject death;
    public Slider hpBar;

    private void Start()
    {
        health = 100;

        hpBar.maxValue = health;
        hpBar.value = health;

        maxHealth = health;
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

        /*
        //For now we delete the player;
        if (health <= 0)
        {
            death.SetActive(true);
            Destroy(this.gameObject);
        }
        */
        // respawn script
        if (health <= 0)
        {
            RespawnPlayer();
        }
        
    }
    public void addHealth(int gain)
    {
        if (health + gain <= maxHealth)
        {
        health += gain;
        }

        Debug.Log(health);
        //update UI
    }

    public void RespawnPlayer()
    {
        player.position = spawn.position;
        health = 100;
        hpBar.value = health;
        this.GetComponent<CharacterController2D>().m_FacingRight = true;
        this.transform.localScale = new Vector2(1f, 1f);
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
