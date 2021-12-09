using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Animator Fading;
    public GameObject location;

    private PlayerMovement movement;

    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            movement = collision.GetComponent<PlayerMovement>();
            StartCoroutine(teleport(collision.gameObject));
        }
    }

    IEnumerator teleport(GameObject player)
    {
        /*
        lock player falling
        play fadeout
        wait
        take control away from player
        teleport player
        play fadein 
        wait
        give control back to player
        */

        //player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;

        Fading.SetBool("teleporting", true);
        yield return new WaitForSeconds(1);
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        movement.paused = true;
        player.transform.position = location.transform.position;
        Fading.SetBool("teleporting", false);
        yield return new WaitForSeconds(1);
        movement.paused = false;
    }

}
