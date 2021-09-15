using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swing : MonoBehaviour
{
    private int damage=50;
    public EnemyHealth script;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            Debug.Log("hit");
            //damage enemy
            ///*
            script = collision.GetComponent<EnemyHealth>();
            script.minusHealth(damage);
            //*/
        }
    }
}
