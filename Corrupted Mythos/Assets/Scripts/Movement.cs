using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public CharacterController cPlayer;
    private Inputs pcontroller;
    private Vector2 desiredDirection;
    private int speed;
    private float gravity = -9.8f;

    private void OnEnable()
    {
        cPlayer = GetComponent<CharacterController>();
        pcontroller = new Inputs();
        pcontroller.Enable();
    }
    private void OnDisable()
    {
        pcontroller.Disable();
    }

    void Start()
    {
        cPlayer = GetComponent<CharacterController>();
    }

    void Update()
    {
        movement();
        if (pcontroller.player.attack.triggered)
        {
            attack();
        }
    }

    void movement()
    {
        desiredDirection.x = pcontroller.player.movement.ReadValue<Vector2>().x;
        cPlayer.Move(desiredDirection * Time.deltaTime * speed);

        /*
        if(pcontroller.player.movement.triggered){ 
            if (pcontroller.player.movement.ReadValue<Vector2>().y>0) //checks if up button is inputed
            {
                //jump
            }
            else if(pcontroller.player.movement.ReadValue<Vector2>().y < 0) //checks if down button is inputed
            {

            }
        }
        */

    }

    void attack()
    {
        //run animation 
        //if hit calc damage
    }
}
