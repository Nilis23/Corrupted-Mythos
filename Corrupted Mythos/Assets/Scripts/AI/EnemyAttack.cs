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
    [Space]
    [SerializeField]
    bool charge = false;
    float t = 0;
    AudioManager manager;

    [Space]
    public EnemyHealth eHealth;
    public bool fG;

    BoxCollider2D box;
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
        //if (box.IsTouching(collision)) { } //Prototype for post animations
        if (collision.gameObject.GetComponent<PlayerHealth>().perfectBlock)
        {

            if (eHealth.GetType() == typeof(OWFrostGiantHealth))
            {
                (eHealth as OWFrostGiantHealth).changeInv();
            }
            else
            {
                eHealth.minusHealth(0, 1);
            }
        }
        collision.gameObject.GetComponent<PlayerHealth>().minusHealth(damage);
        
        GameObject.FindObjectOfType<CameraShake>()?.shakeCam(2, 0.1f, true);
        
    }

    IEnumerator DashAttack(float dist, Collider2D collision)
    {
        float dir;
        if (em.nav.right)
        {
            dir = 1;
        }
        else
        {
            dir = -1;
        }

        Vector2 orgPos = em.transform.position;
        Vector2 newPos = new Vector2(orgPos.x + (dir * dist), orgPos.y);
        float t = 0;
        string[] strings = new string[] { "Platforms", "FrostGiant", "Barriers" };
        int layermask = LayerMask.GetMask(strings);
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(orgPos.x, orgPos.y - 1), new Vector2(dir, 0), dist, layermask);
        RaycastHit2D hitt = Physics2D.Raycast(new Vector2(orgPos.x, orgPos.y + 2), new Vector2(dir, 0), dist, layermask);
        if (hit || hitt)
        {
            float a = Vector2.Distance(hit.point, orgPos);
            float b = Vector2.Distance(hitt.point, orgPos);

            if(a < b)
            {
                newPos = new Vector2(orgPos.x + ((a - 2) * dir), orgPos.y);
            }
            else
            {
                newPos = new Vector2(orgPos.x + ((b - 2) * dir), orgPos.y);
            }
        }
        collision.gameObject.GetComponent<PlayerHealth>().minusHealth(damage, false);
        //Move
        while (t < 0.25f)
        {
            t += Time.deltaTime;
            em.transform.position = Vector2.Lerp(orgPos, newPos, (t / 0.25f));

            yield return null;
        }
        //End
        if (!hit && !hitt)
        {
            em.transform.position = newPos;
        }
        em.attack = false;
        em.setStgr(1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && t <= 0 && em.stagr <= 0)
        {
            t = 1;
            if (!fG)
            {
                em.attack = true;
                animator.SetTrigger("Attack");
                manager.PlaySound("abomHit");
            }

            if (charge) 
            {

                StartCoroutine(DashAttack(10, collision));
            }
            else
            {
                StartCoroutine(DoAttack(collision));
            }
        }
    }
}
