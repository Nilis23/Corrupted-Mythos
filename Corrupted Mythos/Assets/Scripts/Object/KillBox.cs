using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().killPlayer();
        }
        else if(collision.gameObject.tag == "enemy" && !collision.isTrigger)
        {
            Destroy(collision.gameObject);
        }
    }
}
