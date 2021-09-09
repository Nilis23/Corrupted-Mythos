using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    public Animator atk;
    public Transform checkpoint;
    public CharacterController cPlayer;
    public GameObject hitbox;
    private int check=0;
    private bool grounded = false;
    private float gravity = -9.8f;
    private Inputs pcontroller;
    private Vector2 desiredDirection;
    private AudioClip swing;
    private float jumpVelocity = 1f;
    [SerializeField]
    private int speed = 1;

    private void OnEnable()
    {
        //hitbox = transform.GetChild(0);
        //Debug.Log(hitbox.name);
        swing = transform.GetComponent<AudioClip>();
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
            //Debug.Log("attack");
            attack();
        }
        if (pcontroller.player.jump.triggered /*&& grounded*/)
        {
            jump();
        }
        
    }

    void movement()
    {
        desiredDirection.x = pcontroller.player.movement.ReadValue<Vector2>().x;
        cPlayer.Move(desiredDirection * Time.deltaTime * speed);
        
        if(grounded == false)
        {
            desiredDirection.y += gravity *Time.deltaTime;
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

        hitbox.gameObject.SetActive(true);
        hitbox.gameObject.SetActive(false);

    }
    
    void jump()
    {
        //playerbody.velocity = Vector2.up * jumpVelocity;
        //cPlayer.velocity = Vector2.up * jumpVelocity;
        //transform.Translate(0, jumpVelocity * Time.deltaTime, 0);
        //cPlayer.transform.Translate(0, jumpVelocity * Time.deltaTime, 0);
        desiredDirection.y = jumpVelocity;
        Debug.Log("jump");
        grounded = false;
    }

    private void OnTriggerEnter(Collider collision)
    {

        if (collision.CompareTag("floor"))//<--this doesnt get called
        {
            Debug.Log("grounded");
            desiredDirection.y = 0;
            grounded = true;
        }
        else if (collision.CompareTag("checkpoint"))
        {
            checkpoint.position = collision.transform.position;
            check += 1;
            //collision.disable();
        }

    }


}
