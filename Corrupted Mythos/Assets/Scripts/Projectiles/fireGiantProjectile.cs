using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireGiantProjectile : MonoBehaviour
{
    [SerializeField]
    GameObject mySprite;
    [SerializeField]
    CircleCollider2D myCol;
    [SerializeField]
    float step;
    [Space]
    [SerializeField]
    int damage;
    Vector2 dir;

    bool end;
    float life;

    [HideInInspector]
    public Vector2 origin;
    bool defl = false;
    // Start is called before the first frame update
    void Start()
    {
        life = 4f;
        GameObject Player = GameObject.FindGameObjectWithTag("Player");

        dir = (Player.transform.position - this.transform.position).normalized;

        Vector2 targ = Player.transform.position;
        targ.x = targ.x - transform.position.x;
        targ.y = targ.y - transform.position.y;

        float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
        mySprite.transform.rotation = Quaternion.Euler(new Vector3(0, 0, (angle + 90)));
    }

    // Update is called once per frame
    void Update()
    {
        if (!end)
        {
            transform.Translate(dir * Time.deltaTime * step);
        }

        if(life > 0)
        {
            life -= Time.deltaTime;
        }
        else
        {
            StartCoroutine(DoDestruction());
        }
    }
    
    IEnumerator DoDestruction()
    {
        mySprite.GetComponent<Animator>().SetTrigger("End");
        end = true;
        yield return new WaitForSeconds(0.21f);
        Destroy(gameObject);
    }

    public void swapDir()
    {
        dir = (origin - (Vector2)this.transform.position).normalized;
        defl = true;

        step *= 1.5f;

        Vector2 targ = origin;
        targ.x = targ.x - transform.position.x;
        targ.y = targ.y - transform.position.y;

        float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
        mySprite.transform.rotation = Quaternion.Euler(new Vector3(0, 0, (angle + 90)));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !defl)
        {
            StartCoroutine(DoAttack(collision));
        }
        else if(collision.gameObject.tag == "enemy" && defl)
        {
            collision.gameObject.GetComponent<EnemyHealth>().minusHealth(damage);
            StartCoroutine(DoDestruction());
        }
        else
        {
            StartCoroutine(DoDestruction());
        }
    }

    IEnumerator DoAttack(Collider2D collision)
    {
        yield return new WaitForSeconds(0.1f);
        //if (box.IsTouching(collision)) { } //Prototype for post animations
        if (collision.gameObject.GetComponent<PlayerHealth>().perfectBlock)
        {
            swapDir();
        }
        else
        {
            collision.gameObject.GetComponent<PlayerHealth>().minusHealth(damage);

            GameObject.FindObjectOfType<CameraShake>()?.shakeCam(2, 0.01f, true);

            StartCoroutine(DoDestruction());
        }
    }
}
