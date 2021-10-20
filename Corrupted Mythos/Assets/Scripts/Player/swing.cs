using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swing : MonoBehaviour
{
    [SerializeField]
    private int damage = 50;

    AudioManager manager;
    EnemyHealth script;
    bool isAnim = false;
    float t = 0;
    float dt = 0;
    float step = 90f / 5;
    public Animator hit;

    private void Start()
    {
        manager = FindObjectOfType<AudioManager>();
    }

    private void FixedUpdate()
    {
        if (isAnim)
        {
            if (t == 10)
            {
                isAnim = false;
            }
            else
            {
                if (t < 5)
                {
                    transform.Rotate(0, 0, -1 * step);
                }
                else if (t < 10)
                {
                    transform.Rotate(0, 0, step);
                }
            }

            t += 1;
        }
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
            t = 0;
            manager.PlaySound("swing");
        }
    }

    public bool getStatus()
    {
        return isAnim;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.isTrigger && collision.CompareTag("enemy") && isAnim && dt <= 0)
        {
            //damage enemy
            ///*
            script = collision.GetComponent<EnemyHealth>();
            script.minusHealth(damage);
            //*/
            dt = 0.25f;

            Debug.Log("play");
            hit.Play("impact1_0", 0);
            
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.isTrigger && collision.CompareTag("enemy") && isAnim && dt <= 0)
        {
            //damage enemy
            ///*
            script = collision.GetComponent<EnemyHealth>();
            script.minusHealth(damage);
            //*/

            dt = 0.25f;
        }
    }
}
