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
    public EnemyHealth eHealth;

    private void Start()
    {
        manager = FindObjectOfType<AudioManager>();
        eHealth = this.transform.parent.gameObject.GetComponentInParent<EnemyHealth>();
    }

    private void Update()
    {
        if(t > 0)
        {
            t -= Time.deltaTime;
        }
    }

    IEnumerator DoAttack(Collider2D collision)
    {
        yield return new WaitForSeconds(0.1f);
        if (collision.gameObject.GetComponent<PlayerHealth>().perfectBlock)
        {
            eHealth.minusHealth(0, 1);
        }
        collision.gameObject.GetComponent<PlayerHealth>().minusHealth(damage);
        
        GameObject.FindObjectOfType<CameraShake>().shakeCam(2, 0.1f, true);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && t <= 0 && em.stagr <= 0)
        {
            t = 1;
            em.attack = true;

            animator.SetTrigger("Attack");
            manager.PlaySound("abomHit");
            StartCoroutine(DoAttack(collision));
        }
    }
}
