using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    StateManager em;
    [SerializeField]
    int damage;
    [Space]
    [SerializeField]
    Animator animator;
    float t = 0;
    AudioManager manager;

    private void Start()
    {
        manager = FindObjectOfType<AudioManager>();
    }

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
            if (collision.gameObject.GetComponent<PlayerHealth>().perfectBlock)//perfect block
            {
                int i;
                i = damage;
                damage = 0;
                collision.gameObject.GetComponent<PlayerHealth>().minusHealth(damage);
                damage = i;
            }
            else if (collision.gameObject.GetComponent<PlayerHealth>().berserk)//damage if berserked
            {
                damage -= 10;
                collision.gameObject.GetComponent<PlayerHealth>().minusHealth(damage);
                damage += 10;
            }
            else if (collision.gameObject.GetComponent<PlayerHealth>().block)//damage if blocking
            {
                damage -= 15;
                collision.gameObject.GetComponent<PlayerHealth>().minusHealth(damage);
                damage += 15;
            }
            else if (collision.gameObject.GetComponent<PlayerHealth>().block && collision.gameObject.GetComponent<PlayerHealth>().berserk)//damage if both
            {
                damage -= 20;
                collision.gameObject.GetComponent<PlayerHealth>().minusHealth(damage);
                damage += 20;
            }
            else//regular damage
            {
                collision.gameObject.GetComponent<PlayerHealth>().minusHealth(damage);
            }

            t = 1;
            manager.PlaySound("abomHit");
            GameObject.FindObjectOfType<CameraShake>().shakeCam(2, 0.1f, true);
            animator.SetTrigger("Attack");
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && t <= 0 && em.stagr <= 0)
        {
            collision.gameObject.GetComponent<PlayerHealth>().minusHealth(damage);
            t = 1;
            manager.PlaySound("abomHit");
            GameObject.FindObjectOfType<CameraShake>().shakeCam(2, 0.1f, true);
            animator.SetTrigger("Attack");
        }
    }
}
