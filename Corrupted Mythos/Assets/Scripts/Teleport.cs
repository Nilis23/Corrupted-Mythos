using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Animator Fading;
    public Transform location;

    private PlayerMovement movement;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //location.position.z = 0;
            movement = collision.GetComponent<PlayerMovement>();
            StartCoroutine(teleport(collision.gameObject));
        }
    }

    IEnumerator teleport(GameObject player)
    {
        //player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
 
        Fading.SetBool("teleporting", true);
        yield return new WaitForSeconds(1);

        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        movement.paused = true;
        player.transform.position = location.position;

        Fading.SetBool("teleporting", false);
        yield return new WaitForSeconds(1);
        
        movement.paused = false;
    }
}
