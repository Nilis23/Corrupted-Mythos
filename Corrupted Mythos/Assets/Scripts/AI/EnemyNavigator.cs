using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyNavigator : MonoBehaviour
{
    public Vector2 target;

    public float speed = 1;
    public float nWaypointDistance = 3f;

    public Transform gfx;

    [SerializeField]
    StateManager em;
    [SerializeField]
    float bypassDist;

    //private Path path;
    //int currentWP;
    bool reachedEOP = false;

    Seeker seeker;
    Rigidbody2D rb;
    GameObject player;

    float t = 0;
    bool bypass = false;
    bool right = true;

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        reachedEOP = false;

        #region commentStorage
        /*
        if(path == null)
        {
            return;
        }
        else if(currentWP >= path.vectorPath.Count)
        {
            reachedEOP = true;
            return;
        }
        else
        {
            reachedEOP = false;
        }
        */
        #endregion

        if (target != null && em.stagr <= 0 && !em.idle)
        {
            Vector2 dir = ((Vector2)target - (Vector2)rb.position).normalized;
            Vector2 force = dir * (speed * Time.fixedDeltaTime);
            SwapGFX(force);
            //rb.AddForce(force);
            //rb.velocity += new Vector2(force.x, 0);
            //rb.MovePosition( new Vector2((this.transform.position.x + force.x), this.transform.position.y) );
            this.transform.Translate(new Vector2(force.x, 0f));
            #region commentStorage
            //if(t > 10)
            //{
            //Debug.Log("WP: " + currentWP.ToString() + " EndWP: " + path.vectorPath.Count.ToString() + " Force: " + force.ToString() + " RB Vel: " + rb.velocity.ToString() + " X Dir: " + dir.x.ToString() + " Speed: " + speed + " Reached EOP: " + reachedEOP.ToString());
            //t = 9;
            //}

            /*
            float dist = Vector2.Distance(rb.position, path.vectorPath[currentWP]);
            if(dist < nWaypointDistance)
            {
                currentWP++;
                t = 0;
            }
            */
            #endregion

            float dist = Mathf.Abs(rb.position.x - target.x);
            if (dist < nWaypointDistance)
            {
                reachedEOP = true;
                if (em.GetState().GetType() == typeof(attackState))
                {
                    if (!bypass)
                    {
                        BypassTarget();
                    }
                    else
                    {
                        target = player.transform.position;
                        bypass = false;
                    }
                }
            }
        }

        t += Time.deltaTime;
    }

    public void SwapGFX(Vector2 force)
    {
        if (force.x >= 0.01f)
        {
            gfx.localScale = new Vector2(1f, 1f);
            right = true;
        }
        else if (force.x <= -0.01f)
        {
            gfx.localScale = new Vector2(-1f, 1f);
            right = false;
        }
    }

    public void BypassTarget() 
    {
        Vector2 modPos = new Vector2(this.transform.position.x, this.transform.position.y - 1);
        LayerMask mask = ~(1 << 7);
        if (right)
        {
            RaycastHit2D hit = Physics2D.Raycast(modPos, new Vector2(bypassDist, 0), bypassDist, mask);
            if(hit.collider != null && !hit.collider.isTrigger && hit.collider.tag != "Player")
            {
                //float dist = Vector2.Distance(this.transform.position, hit.transform.position);
                float dist = this.transform.position.x - hit.point.x;
                target = new Vector2(this.transform.position.x + (Mathf.Abs(dist) - 2), this.transform.position.y);
                bypass = true;

                Debug.Log("Moving right to dist of " + dist.ToString() + " after hitting " + hit.collider.name);
                return;

            }
            else
            {
                Vector2 pos = new Vector2(transform.position.x + bypassDist, transform.position.y);
                RaycastHit2D down = Physics2D.Raycast(pos, new Vector2(0, -5));
                if(down.collider != null && !down.collider.isTrigger && down.collider.tag != "Player")
                {
                    target = pos;
                    bypass = true;

                    Debug.Log("Moving right at full distance");
                    return;
                }
            }
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(modPos, new Vector2(-1 * bypassDist, 0), bypassDist, mask);
            if (hit.collider != null && !hit.collider.isTrigger && hit.collider.tag != "Player")
            {
                //float dist = Vector2.Distance(this.transform.position, hit.transform.position);
                float dist = this.transform.position.x - hit.point.x;
                target = new Vector2(this.transform.position.x - (Mathf.Abs(dist) - 2), this.transform.position.y);
                bypass = true;

                Debug.Log("Moving left to a dist of " + dist.ToString() + " after hitting " + hit.collider.name);
                return;
            }
            else
            {
                Vector2 pos = new Vector2(transform.position.x - bypassDist, transform.position.y);
                RaycastHit2D down = Physics2D.Raycast(pos, new Vector2(0, -5));
                if (down.collider != null && !down.collider.isTrigger && down.collider.tag != "Player")
                {
                    target = pos;
                    bypass = true;

                    Debug.Log("Moving left at full distance");
                    return;
                }
            }
        }
        Debug.Log("Could not find suitble point in direction looked");
        //bypass = true;
    }


    public bool getEOP()
    {
        return reachedEOP;
    }

    #region A*_Storage
    void OnPathComplete(Path p)
    {/*
        if (!p.error)
        {
            path = p;
            reachedEOP = false;
            currentWP = 0;
        }*/
    }

    public void StartPath(Rigidbody2D rigid, Transform targ)
    {
        seeker.StartPath(rigid.position, targ.position, OnPathComplete);
    }
    #endregion
}
