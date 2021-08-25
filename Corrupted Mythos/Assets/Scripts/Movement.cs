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

    private void OnEnable()
    {
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
    }

    void movement()
    {
        desiredDirection.x = pcontroller.player.movement.ReadValue<Vector2>().x;
        cPlayer.Move(desiredDirection * Time.deltaTime * speed);
    }
}
