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

    float timer;

    private void Start()
    {
        health = 100;

        hpBar.maxValue = health;
        hpBar.value = health;

        maxHealth = health;
    }

    
    void Update()
    {
        if(timer >= 0)
        {
            timer -= Time.deltaTime;

            if(timer <= 0)
            {
                this.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
    }

    public void minusHealth(int damage)
    {
        if (timer <= 0)
        {
            health -= damage;
            Debug.Log(health);
            //update UI
            hpBar.value = health;
            timer = 0.25f;
            this.GetComponent<SpriteRenderer>().color = Color.red;
        }
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
            //Destroy(other);
        }
    }
}
