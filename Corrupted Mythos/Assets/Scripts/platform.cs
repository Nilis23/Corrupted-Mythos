using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    private Inputs character;
    //private bool fall = false;

    private void Start()
    {
        character = new Inputs();
        character.Enable();
    }

    void Update()
    {
        if (character.player.jump.triggered)
        {
            //Debug.Log("up");
            fallThrough();
        }
        else if (character.player.fall.triggered /*&& fall*/)
        {
            //Debug.Log("down");
            flipUp();
        }
    }

    private void fallThrough()// <--- falls through all one way platforms when called 
    {
        this.GetComponent<PlatformEffector2D>().rotationalOffset = 0;
    }
    private void flipUp()
    {
        this.GetComponent<PlatformEffector2D>().rotationalOffset = 180;
    }
    ///* <---causes player to hit head on platform if they dont jump all the way through 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            //fall = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
           // fall = false;
            fallThrough();
        }
    }
    //*/
}
