using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHurting : MonoBehaviour
{
    private int damage = 10;
    public PlayerHealth script;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            Debug.Log("hit");
            //damage player
            ///*
            script = collision.GetComponent<PlayerHealth>();
            script.minusHealth(damage);
            //*/
        }
    }
}
