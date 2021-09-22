using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    StateManager em;
    [SerializeField]
    int damage;
    float t = 0;

    private void Update()
    {
        if(t > 0)
        {
            t -= Time.deltaTime;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && t <= 0 && em.stagr <= 0)
        {
            collision.gameObject.GetComponent<PlayerHealth>().minusHealth(damage);
            t = 1;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && t <= 0 && em.stagr <= 0)
        {
            collision.gameObject.GetComponent<PlayerHealth>().minusHealth(damage);
            t = 1;
        }
    }
}
