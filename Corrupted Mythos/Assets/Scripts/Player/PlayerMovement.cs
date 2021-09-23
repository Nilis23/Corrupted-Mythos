using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D cntrler;
    public float speed;
    public swing weap;
    public GameObject pause;

    private Inputs pcontroller;
    private float dir;
    private Vector2 desiredDirection;

    private bool jump = false;
    public bool paused = false;

    // Start is called before the first frame update
    void Start()
    {
        pcontroller = new Inputs();
        pcontroller.Enable();
    }

    // Update is called once per frame
    void Update()
    {

        if (pcontroller.player.Pause.triggered)
        {
            pause.SetActive(true);
            paused = true;
        }

        dir = pcontroller.player.movement.ReadValue<Vector2>().x * speed;

        if (pcontroller.player.jump.triggered && !paused)
        {
            jump = true;
        }
        if (pcontroller.player.attack.triggered && !paused)
        {
            Debug.Log("atk");
            weap.attack();
        }
    }
    private void FixedUpdate()
    {
        if (!paused)
        {
            cntrler.Move(dir * Time.fixedDeltaTime, false, jump);
            jump = false;
        }
    }
}
