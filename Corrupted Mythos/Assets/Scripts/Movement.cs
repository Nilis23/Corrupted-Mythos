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
    private Rigidbody2D playerbody;
    private BoxCollider2D playerbox;
    private float jumpVelocity = 10f;
    [SerializeField]
    private int speed = 1;

    private void OnEnable()
    {
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
    }

    void movement()
    {
        desiredDirection.x = pcontroller.player.movement.ReadValue<Vector2>().x;
        cPlayer.Move(desiredDirection * Time.deltaTime * speed);

        
        if(pcontroller.player.movement.triggered){ 
            if (pcontroller.player.movement.ReadValue<Vector2>().y>0 && isGrounded()) //checks if up button is inputed
            {
                //jump
                playerbody.velocity = Vector2.up * jumpVelocity;
                
            }
            else if(pcontroller.player.movement.ReadValue<Vector2>().y < 0) //checks if down button is inputed
            {

            }
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



        return raycastHit2D.collider != null;
    }
}
