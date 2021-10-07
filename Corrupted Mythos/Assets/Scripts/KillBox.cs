using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().minusHealth(1000);
        }
        else if(collision.gameObject.tag == "enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().minusHealth(1000);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().minusHealth(100);
        }
    }
}
