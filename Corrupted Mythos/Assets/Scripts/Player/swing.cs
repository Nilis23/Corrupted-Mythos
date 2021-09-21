using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swing : MonoBehaviour
{
    private int damage = 50;
    
    EnemyHealth script;
    bool isAnim = false;
    float t = 0;
    float dt = 0;

    private void Update()
    {
        if (isAnim)
        {
            t -= Time.deltaTime;
            if(t <= 0)
            {
                isAnim = false;
            }

            if(t >= 0.25)
            {
                transform.Rotate(0, 0, Time.deltaTime * -240);
            }
            else
            {
                transform.Rotate(0, 0, Time.deltaTime * 240);
            }
        }
        if(dt >= 0)
        {
            dt -= Time.deltaTime;
        }
    }

    public void attack()
    {
        if (!isAnim)
        {
            isAnim = true;
            t = 0.5f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.isTrigger && collision.CompareTag("enemy") && isAnim && dt <= 0)
        {
            Debug.Log("hit");
            //damage enemy
            ///*
            script = collision.GetComponent<EnemyHealth>();
            script.minusHealth(damage);
            //*/
            dt = 1;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.isTrigger && collision.CompareTag("enemy") && isAnim && dt <= 0)
        {
            Debug.Log("hit");
            //damage enemy
            ///*
            script = collision.GetComponent<EnemyHealth>();
            script.minusHealth(damage);
            //*/

            dt = 1;
        }
    }
}
