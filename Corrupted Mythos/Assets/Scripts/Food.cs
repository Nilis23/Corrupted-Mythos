using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private int hpGain = 10;
    public PlayerHealth script;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Collision event firing");
            script = collision.gameObject.GetComponent<PlayerHealth>();
            script.addHealth(hpGain);

            Destroy(gameObject);
        }
    }
}
