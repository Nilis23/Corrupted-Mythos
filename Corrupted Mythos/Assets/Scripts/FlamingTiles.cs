using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamingTiles : MonoBehaviour
{

    public int damage = 20;
    public PlayerHealth script;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")//<--could change to while loop(?)
        {
            script = collision.GetComponent<PlayerHealth>();
            script.minusHealth(damage);
            //need it to repeat based on time standing on tile
        }
    }
}
