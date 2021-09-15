using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testProjLaunch : MonoBehaviour
{
    projectileManager manager;
    [SerializeField]
    GameObject targ;

    bool inRange = false;
    // Start is called before the first frame update
    void Start()
    {
        //targ = GameObject.FindGameObjectWithTag("Player");
        manager = this.GetComponent<projectileManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            Vector2 dir = (targ.transform.position - this.transform.position).normalized;
            Ray2D ray = new Ray2D(this.transform.position, dir);
            Debug.DrawRay(this.transform.position, dir * 20f);

            RaycastHit2D rayHit = Physics2D.Raycast(this.transform.position, dir);

            if (rayHit)
            {
                rayHit.collider.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                if (rayHit.collider.gameObject == targ)
                {
                    manager.attemptProjectileLaunch(this.gameObject);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == targ)
        {
            inRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == targ)
        {
            inRange = false;
        }
    }
}
