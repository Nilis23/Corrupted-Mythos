using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D cntrler;
    public Animator animatior;
    [Space]
    [SerializeField]
    PlayerHealth playerHP;
    [Space]
    public float speed;
    public swing weap;
    public GameObject pause;
    public GameObject dashbox;
    public bool paused = false;
    public PlayerHealth playerHealth;
    public Transform impact;

    public Inputs pcontroller;
    private float dir;
    private bool Bactive;
    private bool jump = false;
    private float dashTimer;
    private bool slam = false;
    private bool chkAttk;
    private GameObject godWipe;

    bool block;

    public int killCount;
    public ParticleSystem wipe;
    public CameraShake shaker;
    public GodBarControl GodBarctrl;

    [SerializeField]
    ImageController dash;
    [SerializeField]
    GameObject SlamEffect;

    public GameObject beserkLocator;

    private void OnEnable()
    {
        EnemyHealth.EnemyDied += IncrementKill;
        IconOfDestruction.IconDestroyed += FillKill;
        pcontroller = new Inputs();
        //pcontroller.player.block.started += BlockOn;
        //pcontroller.player.block.canceled += BlockOff;
    }

    private void OnDisable()
    {
        EnemyHealth.EnemyDied -= IncrementKill;
        IconOfDestruction.IconDestroyed -= FillKill;
        //pcontroller.player.block.started -= BlockOn;
        //pcontroller.player.block.canceled -= BlockOff;
    }

    void Start()
    {
        impact = transform.Find("impact").gameObject.transform;
        godWipe = transform.Find("GodWipe").gameObject;
        Debug.Log("godwipe = " +godWipe);
        pcontroller.Enable();
        playerHealth = this.GetComponentInParent<PlayerHealth>();

        //testFunc = IncrementKill;
    }

    private void BlockOn(InputAction.CallbackContext c)
    {
        speed -= 40;
        playerHealth.block = true;
        StartCoroutine(PerfectBlock());
    }
    private void BlockOff(InputAction.CallbackContext c)
    {
        if (block)
        {
            speed = 40;
            playerHealth.block = false;
            block = false;
            pcontroller.player.Defend.canceled -= BlockOff;
        }
        else
        {
            return;
        }
    }

    void Update()
    {
        dir = 0;

        if (pcontroller.player.Pause.triggered)
        {
            pause.SetActive(true);
            paused = true;
            Time.timeScale = 0f;
        }

        if (!weap.getStatus() && !paused && !playerHealth.block && slam != true && !chkAttk)
        {
            dir = pcontroller.player.movement.ReadValue<Vector2>().x;
            if (dir != 0)
            {
                if (dir < 0)
                {
                    dir = -1 * speed;
                }
                else
                {
                    dir = 1 * speed;
                }
            }
            if (cntrler.m_Grounded)
            {
                animatior.SetFloat("Speed", Mathf.Abs(dir));
            }
            else
            {
                animatior.SetFloat("Speed", 0f);
            }

            if (pcontroller.player.Defend.triggered)
            {
                if (dir != 0)
                {
                    if (dir > 0 && dashTimer < 0f)
                    {
                        StartCoroutine(Dash(1f));
                        dashTimer = 1.25f;
                        dash.DeactivateImage();
                        animatior.SetTrigger("Dash");
                    }
                    else if (dir < 0 && dashTimer < 0f)
                    {
                        StartCoroutine(Dash(-1f));
                        dashTimer = 1.25f;
                        dash.DeactivateImage();
                        animatior.SetTrigger("Dash");
                    }
                }
                else
                {
                    if (!block)
                    {
                        speed = 0;
                        playerHealth.block = true;
                        StartCoroutine(PerfectBlock());
                        block = true;
                        pcontroller.player.Defend.canceled += BlockOff;
                    }
                }
            }
        }
        else
        {
            animatior.SetFloat("Speed", 0);
        }

        if (pcontroller.player.jump.triggered && !paused && !weap.getStatus() && !playerHealth.block && slam != true)
        {
            jump = true;
        }
        if (pcontroller.player.attack.triggered && !paused && !playerHealth.block && !chkAttk && !slam)
        {
            if (cntrler.m_Grounded == false && !slam)
            {
                slam = true;
                StartCoroutine(SlamAttack());
                weap.attack(false);
            }
            else
            {
                //weap.attack();
                StartCoroutine(DetermineAttack());
            }
        }
        if (pcontroller.player.Heal.triggered)
        {
            playerHP.doPotion();
        }
        if (pcontroller.player.berserk.triggered)
        {
            if (playerHealth.berserk)
            {
                gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.red;
                impact.GetComponent<SpriteRenderer>().color = Color.magenta;
                speed += 20;
                StartCoroutine(rageMode());
            }
        }
        if (pcontroller.player.GodWipe.triggered && killCount >= 15)
        {
            Debug.Log("wipe");
            //kill enemies on screen 
            godWipe.SetActive(true);
            //godWipe.SetActive(false);
            killCount = 0;
            GodBarctrl.ResetBar();
            //visual bloom
            wipe.Play();
            //screen shake
            shaker.shakeCam(1, 1);
        }

        dashTimer -= Time.deltaTime;
        if (dashTimer! < 0)
        {
            dashTimer -= Time.deltaTime;
            if (dashTimer <= 0)
            {
                dash.ActivateImage();
            }
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
        GodBarctrl.ResetBar();
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

    IEnumerator DetermineAttack()
    {
        float t = 0;
        chkAttk = true;
        float max = 0.25f;
        bool anim = false;

        while(pcontroller.player.attack.ReadValue<float>() > 0)
        {
            t += Time.deltaTime;
            if(t > max && !anim)
            {
                //Play animation part one
                animatior.SetTrigger("LongSwing");
                anim = true;
            }
            yield return new WaitForEndOfFrame();
        }

        if(t < max)
        {
            weap.attack();
        }
        else if(t >= max)
        {
            int mod;
            if(t < 1.75)
            {
                mod = (int)((t / 1.75) * 3);
            }
            else
            {
                mod = 3;
            }

            if(mod == 0)
            {
                mod = 1;
            }

            Debug.Log(mod);
            weap.attack(true, true, mod);
        }

        chkAttk = false;
    }

    IEnumerator Dash(float dir)
    {
        //preperatory work
        paused = true;
        float t = 0;
        playerHealth.inv = true;
        dashbox.SetActive(true);
        Vector2 targPos = new Vector2(transform.position.x + (5 * dir), transform.position.y);
        Vector2 orgPos = transform.position;
        string[] strings = new string[] { "Platforms", "FrostGiant", "Barriers" };
        int layermask = LayerMask.GetMask(strings);
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 1), new Vector2(dir, 0), 5, layermask);
        RaycastHit2D hitt = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + 2), new Vector2(dir, 0), 5, layermask);
        if (hit || hitt)
        {
            float a = Vector2.Distance(hit.point, orgPos);
            float b = Vector2.Distance(hitt.point, orgPos);

            if (a < b)
            {
                targPos = new Vector2(orgPos.x + ((a - 0.5f) * dir), orgPos.y);
                t = (0.25f * (5 / a));
            }
            else
            {
                targPos = new Vector2(orgPos.x + ((b - 0.5f) * dir), orgPos.y);
                t = (0.25f * (5 / b));
            }

            animatior.speed = 0.25f / t;
        }
        //Move
        while (t < 0.25f)
        {
            t += Time.deltaTime;
            transform.position = Vector2.Lerp(orgPos, targPos, (t / 0.25f));

            yield return null;
        }
        //End
        playerHealth.inv = false;
        if (!hit && !hitt)
        {
            transform.position = targPos;
        }
        dashbox.SetActive(false);
        paused = false;
        animatior.speed = 1f;
    }

    IEnumerator rageMode()
    {
        float i;
        //deplete the berserk mode bar
        Bactive = true;
        playerHealth.berserking = true;

        for (i = 0; i < 5; i++)
        {
            playerHealth.rageCounter -= 20;
            playerHealth.rageMeter.loseHP(20);
            yield return new WaitForSeconds(2);
        }

        //yield return new WaitForSeconds(10);

        playerHealth.rageCounter = 0;
        playerHealth.rageMeter.setCurHP(0);

        speed -= 20;
        playerHealth.berserk = false;
        playerHealth.berserking = false;

        Bactive = false;
        //Debug.Log("unberserking");
        gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.white;
        impact.GetComponent<SpriteRenderer>().color = Color.white;
    }

    IEnumerator PerfectBlock()
    {
        SpriteRenderer sr = gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
        playerHealth.perfectBlock = true;
        sr.color = Color.gray;
        yield return new WaitForSeconds(.5f);
        playerHealth.perfectBlock = false;
        sr.color = Color.white;
    }

    IEnumerator SlamAttack()
    {
        //Fall speed up and then wait until groudned
        cntrler.m_Rigidbody2D.gravityScale = 8;
        playerHealth.inv = true;
        yield return new WaitWhile(() => cntrler.m_Grounded == false);

        //do the actual slam things
        animatior.SetTrigger("SlamLand");
        SlamEffect.SetActive(true);
        cntrler.m_Rigidbody2D.gravityScale = 3;
        GameObject.FindObjectOfType<CameraShake>()?.shakeCam(7, 0.2f, true);
        //Find and damage enemeies
        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(this.transform.position, new Vector2(8, 3), 0f);
        foreach(Collider2D col in hitColliders)
        {
            if(col.tag == "enemy")
            {
                col.gameObject.GetComponent<EnemyHealth>()?.minusHealth(50, 10);
            }
        }

        //Wait for end of frame and wrap up
        yield return new WaitForSeconds(0.2f);
        playerHealth.inv = false;
        slam = false;
        weap.UnAttack();
    }

    public void IncrementKill()
    {
        killCount++;
        if (GodBarctrl != null)
        {
            GodBarctrl.IncrementBar(GodBarctrl.GetFullSize() / 15);
        }
    }
    public void FillKill()
    {
        killCount = 15;
        GodBarctrl.IncrementBar(GodBarctrl.GetFullSize());
    }
}
