using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireGiantProjectile : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer mySprite;
    [SerializeField]
    CircleCollider2D myCol;
    [SerializeField]
    float step;
    Vector2 dir;

    float life;

    // Start is called before the first frame update
    void Start()
    {
        life = 1000f;

        dir = (GameObject.FindGameObjectWithTag("Player").transform.position - this.transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(dir * Time.deltaTime * step);

        if(life > 0)
        {
            life -= Time.deltaTime;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void activateCol()
    {
        myCol.enabled = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
    
}
