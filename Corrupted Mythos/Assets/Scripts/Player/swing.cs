using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swing : MonoBehaviour
{
    [SerializeField]
    private int damage = 50;
    private int berserkDamage = 100;
    [SerializeField]
    GameObject impact;

    AudioManager manager;
    EnemyHealth script;
    bool isAnim = false;
    //float t = 0;
    float dt = 0;
    //float step = 90f / 5;
    public Animator animator;
    public bool hit = false;
    public PlayerHealth PlayerHealth;
    private int lifesteal;

    private void OnEnable()
    {
        PlayerHealth = this.GetComponentInParent<PlayerHealth>();
        impact.SetActive(false);
    }

    private void Start()
    {
        manager = FindObjectOfType<AudioManager>();
            lifesteal = 10;
        Debug.Log(manager.name);
    }

    private void FixedUpdate()
    {
        if(dt >= 0)
        {
            dt -= Time.fixedDeltaTime;
        }
    }

    public void attack()
    {
        if (!isAnim)
        {
            isAnim = true;
            //t = 0;
            manager.PlaySound("swing");
            animator.SetTrigger("S2");
            Invoke("UnAttack", 0.55f);
        }
    }

    public void UnAttack()
    {
        isAnim = false;
    }

    public bool getStatus()
    {
        return isAnim;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (PlayerHealth.block)
        {
            //do nothing
        }

        else if (!collision.isTrigger && collision.CompareTag("enemy") && isAnim && dt <= 0 && hit && PlayerHealth.berserk)
        {
            impact.SetActive(false);

            script = collision.GetComponent<EnemyHealth>();
            script.minusHealth(berserkDamage, 1);
            dt = 0.56f;

            PlayerHealth.addHealth(lifesteal);
            impact.SetActive(true);
            impact.transform.position = transform.position;
            StartCoroutine(Wait());
        }

        else if (!collision.isTrigger && collision.CompareTag("enemy") && isAnim && dt <= 0 && hit)
        {
            impact.SetActive(false);

            script = collision.GetComponent<EnemyHealth>();
            script.minusHealth(damage, 1);
            dt = 0.56f;
            PlayerHealth.rageCounter += 50;
            PlayerHealth.enrage();

            impact.SetActive(true);
            impact.transform.position = transform.position;
            StartCoroutine(Wait());
        }

        else if(!collision.isTrigger && collision.CompareTag("Dummy") && isAnim && dt <= 0 && hit)
        {
            impact.SetActive(false);

            collision.GetComponent<DummyHealth>()?.doDamage(damage);
            dt = 0.56f;

            impact.SetActive(true);
            impact.transform.position = transform.position;
            StartCoroutine(Wait());
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.isTrigger && collision.CompareTag("enemy") && isAnim && dt <= 0 && hit)
        {
            script = collision.GetComponent<EnemyHealth>();
            script.minusHealth(damage, 1);

            dt = 0.56f;

            impact.SetActive(true);
            impact.transform.position = transform.position;
            StartCoroutine(Wait());
        }
        else if (!collision.isTrigger && collision.CompareTag("Dummy") && isAnim && dt <= 0 && hit)
        {
            impact.SetActive(false);

            collision.GetComponent<DummyHealth>()?.doDamage(damage);
            dt = 0.56f;

            impact.SetActive(true);
            impact.transform.position = transform.position;
            StartCoroutine(Wait());
        }
    }

    internal void setHit(bool lean)
    {
        hit = lean;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        impact.SetActive(false);
    }
}
