using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public bool berserk;
    public bool berserking;
    public float rageCounter;
    public bool block;
    public bool perfectBlock;

    public int points;
    public Text pointScore;
    public int deathCount;

    public GameObject Pcamera;
    public GameObject Fcamera;

    public Color hurtFlash;
    public int health, check=0, maxHealth;
    public Transform player;
    public Transform spawn;
    public GameObject death;
    public LazyUIBar hpBar;
    public LazyUIBar rageMeter;
    public PlayerMovement script;
    public int lives;
    public ParticleSystem berserkBarEffect;

    [HideInInspector]
    public CorruptedNode node;

    float timer;
    public int hpGainItems;

    public bool inv = false;

    [Space]
    [SerializeField]
    Animator PlayerAnim;

    private void Start()
    {
        hpBar = GameObject.Find("HPBar")?.GetComponent<LazyUIBar>();
        rageMeter = GameObject.Find("Berserk")?.GetComponent<LazyUIBar>();
        hurtFlash = Color.red;
        health = 100;
        rageCounter = 0;

        if (rageMeter != null)
        {
            rageMeter.maxHP = 100;
            SetBerserkUI();
        }

        hpBar.maxHP = health;
        hpBar.setCurHP(health);

        maxHealth = health;

        script = this.gameObject.GetComponent<PlayerMovement>();
        lives = 10;
    }

    
    void Update()
    {
        if(timer >= 0)
        {
            timer -= Time.deltaTime;
        }
    }

    public void minusHealth(int damage, bool blockable = true)
    {
        if (!inv)
        {
            if (perfectBlock && blockable)
            {
                hurtFlash = Color.yellow;
                damage = 0;
            }
            else if (block && blockable)
            {
                hurtFlash = Color.gray;
                damage -= 15;
            }

            if (timer <= 0 && berserking)
            {
                damage -= 10;
            }

            if (timer <= 0)
            {
                health -= damage;
                //update UI
                hpBar.loseHP(damage);
                timer = 0.25f;

                enrage(5);

                StartCoroutine(FlashObject(gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>(), Color.white, hurtFlash, 1f, 0.5f));
            }
            if (perfectBlock)
            {
                hurtFlash = Color.red;
            }
            // respawn script
            if (health <= 0)
            {
                //RespawnPlayer();
                PlayerAnim.SetTrigger("Die");
                script.paused = true;
                Invoke("DeathScreen", 0.2f);
            }
        }
        
    }

    void DeathScreen()
    {
        death.SetActive(true);
        Time.timeScale = 0f;
    }

    public void killPlayer()
    {
        Time.timeScale = 0f;
        death.SetActive(true);
    }

    public void addHealth(int gain)
    {
        if (health + gain <= maxHealth)
        {
            health += gain;
        }
        else
        {
            health = maxHealth;
        }

        hpBar.gainHP(gain);
    }

    public void RespawnPlayer()
    {
        GameObject sr = gameObject.transform.GetChild(0).gameObject;
        PlayerAnim.SetTrigger("Respawn");

        if (Pcamera.activeInHierarchy == false)
        {
            Pcamera.SetActive(true);
            Fcamera.SetActive(false);
        }
        

        death.SetActive(false);

        player.position = spawn.position;
        health = 100;
        rageCounter = 0;
        if (rageMeter != null)
        {
            SetBerserkUI();
        }
        hpBar.setCurHP(health);
        this.GetComponent<CharacterController2D>().m_FacingRight = true;
        sr.GetComponent<SpriteRenderer>().color = Color.white;
        this.transform.localScale = new Vector2(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y);
        StopAllCoroutines();
        script.spawning();

        if(node != null)
        {
            node.ResetNodeActivity();
            node.active = false;
            node = null;
        }

        sr.GetComponent<Animator>()?.SetFloat("Speed", 0f);
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        deathCount += 1;
        points = points - (points / 10 / 2);

        lives--;
        //update UI
        if (lives <= 0)
        {
            Debug.Log("resetting");
            //restart scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //Application.LoadLevel(Application.loadedLevel);
        }
    }
    IEnumerator FlashObject(SpriteRenderer toFlash, Color originalColor, Color flashColor, float flashTime, float flashSpeed)
    {
        float flashingFor = 0;
        Color newColor = flashColor;
        while (flashingFor < flashTime)
        {
            toFlash.color = newColor;
            flashingFor += Time.deltaTime;
            yield return new WaitForSeconds(flashSpeed);
            flashingFor += flashSpeed;
            if (newColor == flashColor)
            {
                newColor = originalColor;
            }
            else
            {
                newColor = flashColor;
            }
        }
    }

    public void doPotion()
    {
        if(hpGainItems > 0 && health != maxHealth)
        {
            addHealth(30);
            hpGainItems--;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("checkpoint"))
        {
            spawn.position = new Vector3(other.transform.position.x, other.transform.position.y + 1, transform.position.z);
            check += 1;

        }
    }

    public void enrage(float val)
    {
        if (rageMeter != null)
        {
            rageCounter += val;

            //fill rage meter
            SetBerserkUI();
            if (rageCounter >= 100)
            {
                berserk = true;
            }
        }
    }

    public void FillBerserk()
    {
        float diff = 100 - rageCounter;
        enrage(diff);
        Debug.Log("Filled bar");
        Debug.Log(rageCounter);
    }
    
    public void SetBerserkUI()
    {
        rageMeter.setCurHP(rageCounter);
        if (rageCounter >= 100)
        {
            //play effect
        }
    }
}
