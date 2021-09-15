using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health, check=0;
    public Transform player;
    public Transform spawn;

    void Update()
    {
        if (health <= 0)
        {
            player.position = spawn.position;
            health = 100;
        }
    }

    public void minusHealth(int damage)
    {
        health -= damage;
        Debug.Log(health);
        //update UI
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
