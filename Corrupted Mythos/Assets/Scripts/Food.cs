using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private int damage = 10;
    public PlayerHealth script;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            script = collision.GetComponent<PlayerHealth>();
            script.addHealth(damage);
        }
    }
}
