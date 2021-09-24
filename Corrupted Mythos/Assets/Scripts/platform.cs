using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    private Inputs character;

    private void Start()
    {
        character = new Inputs();
        character.Enable();
    }

    void Update()
    {
        if (character.player.jump.triggered)
        {
            Debug.Log("up");
            fallThrough();
        }
        else if (character.player.fall.triggered)
        {
            Debug.Log("down");
            flipUp();
        }
    }

    private void fallThrough()
    {
        this.GetComponent<PlatformEffector2D>().rotationalOffset = 0;
    }
    private void flipUp()
    {
        this.GetComponent<PlatformEffector2D>().rotationalOffset = 180;
    }
}
