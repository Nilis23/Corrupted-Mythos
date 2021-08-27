using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public Animator atk;
    public CharacterController cPlayer;
    private Inputs pcontroller;
    private Vector2 desiredDirection;
    private AudioClip swing;
    private Rigidbody2D playerbody;
    private BoxCollider2D playerbox;
    private float jumpVelocity = 10f;
    [SerializeField]
    private int speed = 1;

    private void OnEnable()
    {
        swing = transform.GetComponent<AudioClip>();
        playerbox = transform.GetComponent<BoxCollider2D>();
        playerbody = transform.GetComponent<Rigidbody2D>();
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
        if (pcontroller.player.jump.triggered)
        {
            jump();
        }
    }

    void movement()
    {
        desiredDirection.x = pcontroller.player.movement.ReadValue<Vector2>().x;
        cPlayer.Move(desiredDirection * Time.deltaTime * speed);

         
        if (pcontroller.player.movement.ReadValue<Vector2>().y > 0 && isGrounded()) 
        {
        //jump
        playerbody.velocity = Vector2.up * jumpVelocity;
                
        }
        else if(pcontroller.player.movement.ReadValue<Vector2>().y < 0) 
        {

        }
        

    }

    void attack()
    {
        //run animation 
        /*
        if (check if "space is false")
        {
            atk.SetBool("space", true);
        }else{do nothing}
        */
        //if hit calc damage

    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(playerbox.bounds.center, playerbox.bounds.size, 0f, Vector2.down, .1f);

        Debug.Log(raycastHit2D);

        return raycastHit2D.collider != null;
    }

    void jump()
    {
        playerbody.velocity = Vector2.up * jumpVelocity;
    }
}
