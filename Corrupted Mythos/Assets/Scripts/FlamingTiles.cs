using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamingTiles : MonoBehaviour
{

    public int damage = 20;
    private float time;
    private bool flaming=false;
    public PlayerHealth script;

    private void Update()
    {
        if (flaming)
        {
            time += Time.deltaTime;
        }

        if (time>=1f)
        {
            script.minusHealth(damage);
            time = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            script = collision.GetComponent<PlayerHealth>();
            flaming = true;
        } 
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            script = collision.gameObject.GetComponent<PlayerHealth>();
            flaming = false;
        }
        
    }
}
