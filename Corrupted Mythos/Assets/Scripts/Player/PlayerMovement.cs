using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D cntrler;
    public Animator animatior;
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
    private bool walking;

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

        if (!weap.getStatus() && !paused)
        {
            dir = pcontroller.player.movement.ReadValue<Vector2>().x * speed;
            animatior.SetFloat("Speed", Mathf.Abs(dir));
        }
        else
        {
            animatior.SetFloat("Speed", 0);
        }

        if (pcontroller.player.jump.triggered && !paused && !weap.getStatus())
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
        if (pcontroller.player.berserk.triggered)
        {
            /*
            if (berserk)
            {
                //turn player red
                //turn impact red/purple
                StartCoroutine(rageMode());
            }
            */
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

    public void spawning()
    {
        StartCoroutine(SpawnedIn());
    }

    public void ToggleSwingBox(bool lean)
    {
        GetComponentInChildren<swing>()?.setHit(lean);
    }

    IEnumerator SpawnedIn()
    {
        paused = true;
        yield return new WaitForSeconds(1);
        paused = false;
    }

    /*
    IEnumerator rageMode()
    {
        //deplete the berserk mode bar
        berserk = false;
    }
    */
}
