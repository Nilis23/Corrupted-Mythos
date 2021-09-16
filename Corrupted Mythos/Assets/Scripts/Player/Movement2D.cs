using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement2D : MonoBehaviour
{
    public Animator atk;
    public Rigidbody2D playerRB;
    public swing weap;
    public GameObject pause;

    private bool grounded = false;
    //private float gravity = -9.8f;

    private Inputs pcontroller;

    private Vector2 desiredDirection;
    
    private AudioClip swing;

    [Tooltip("The modifier for how much the player moves. 0 will mean no movement, higher numbers mean faster movement.")]
    [SerializeField] private float speed = 1; //Modifier for how fast the player moves
    [Tooltip("The force applied on jump. Bigger means higher jump.")]
    [SerializeField] private float jumpVelocity = 1f; //Modifier for how high the player jumps

    bool paused;

    private void OnEnable()
    {
        //hitbox = transform.GetChild(0);
        //Debug.Log(hitbox.name);
        swing = transform.GetComponent<AudioClip>();
        pcontroller = new Inputs();
        pcontroller.Enable();

        /*
        hitbox = transform.GetChild(0).gameObject;
        Debug.Log(hitbox.name);
        */
    }
    private void OnDisable()
    {
        pcontroller.Disable();
    }

    void Start()
    {
        playerRB = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        desiredDirection = playerRB.velocity;
        desiredDirection.x = (pcontroller.player.movement.ReadValue<Vector2>().x * speed);
        if (pcontroller.player.jump.triggered && grounded)
        {
            desiredDirection.y = jumpVelocity;
            grounded = false;
        }
        if (pcontroller.player.attack.triggered)
        {
            Debug.Log("atk");
            attack();
        }
        /*
        if (pcontroller.player.Pause.triggered)
        {
            pause.SetActive(true);
            //paused = true;
        }
        */
        playerRB.velocity = desiredDirection;

        if(desiredDirection.x > 0)
        {
            this.transform.localScale = new Vector2(1f, 1f);
        }
        else if(desiredDirection.x < 0)
        {
            this.transform.localScale = new Vector2(-1f, 1f);
        }
    }

    void attack()
    {
        /*attack animation
        if (atk.GetBool("attack") == false) //atk's attack goes back to false at end of animation
        {
            atk.SetBool("attack", true);
        }else{}
        */

        //hitbox.gameObject.SetActive(true);
        //hitbox.gameObject.SetActive(false);

        weap.attack();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("floor"))
        {
            Debug.Log("grounded");
            //desiredDirection.y = 0;
            grounded = true;
        }
    }
}
