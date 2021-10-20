using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D cntrler;
    [SerializeField]
    PlayerHealth playerHP;
    [Space]
    public float speed;
    public swing weap;
    public GameObject pause;

    private Inputs pcontroller;
    private float dir;
    private Vector2 desiredDirection;

    private bool jump = false;
    private bool atk;
    public bool paused = false;

    void Start()
    {
        pcontroller = new Inputs();
        pcontroller.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        dir = 0;

        if (pcontroller.player.Pause.triggered)
        {
            pause.SetActive(true);
            paused = true;
            Time.timeScale = 0f;
        }

        if (!weap.getStatus())
        {
            dir = pcontroller.player.movement.ReadValue<Vector2>().x * speed;
        }
        else
        {
            dir = (pcontroller.player.movement.ReadValue<Vector2>().x * speed)/1.5f;
        }

        if (pcontroller.player.jump.triggered && !paused)
        {
            jump = true;
        }
        if (pcontroller.player.attack.triggered && !paused)
        {
            weap.attack();
        }
        if (pcontroller.player.Heal.triggered)
        {
            playerHP.doPotion();
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
