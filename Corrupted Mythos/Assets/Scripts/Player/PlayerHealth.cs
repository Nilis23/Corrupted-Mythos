using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health, check=0;
    public Transform player;
    public Transform spawn;
    public GameObject death;

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

        //For now we delete the player;
        if (health <= 0)
        {
            death.SetActive(true);
            //Destroy(this.gameObject);
            Invoke("reloadScene", 2);
        }
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

    public void reloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
