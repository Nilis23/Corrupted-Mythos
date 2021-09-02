using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public Transform player;
    void Update()
    {
        if (health <= 0)
        {
            //Application.Quit;
        }
    }

    public void minusHealth(int damage)
    {
        health -= damage;
        //update UI
    }
    public void addHealth(int gain)
    {
        health += gain;
        //update UI
    }
}
