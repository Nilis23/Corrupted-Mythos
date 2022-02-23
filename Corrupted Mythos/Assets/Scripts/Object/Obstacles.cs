using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public int damage;
    private PlayerHealth script;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            script = collision.gameObject.GetComponent<PlayerHealth>();
            script.minusHealth(damage);
            script.knockAround();
        }
    }
}
