using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyNavigator : MonoBehaviour
{
    public Vector2 target;

    public float speed = 1;
    public float nWaypointDistance = 3f;

    //public Transform gfx;

    [SerializeField]
    StateManager em;
    [SerializeField]
    float bypassDist;
    [SerializeField]
    State Attack;
    [Space]
    [SerializeField]
    bool doBypass = false;

    //private Path path;
    //int currentWP;
    bool reachedEOP = false;

    Seeker seeker;
    Rigidbody2D rb;
    GameObject player;

    float t = 0;
    float speedMod = 0;
    bool bypass = false;
    bool right = true;

    // Start is called before the first frame update
    void Start()
    {
        //seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        reachedEOP = false;

        if (target != null && em.stagr <= 0 && !em.idle && !em.attack)
        {
            Vector2 dir = (target - rb.position).normalized;
            Vector2 force = dir * (speed * Time.fixedDeltaTime);
            SwapGFX(force);
            this.transform.Translate(new Vector2(force.x, 0f));

            float dist = Mathf.Abs(rb.position.x - target.x);
            if (dist < nWaypointDistance)
            {
                reachedEOP = true;
                if (doBypass && em.GetState().GetType() == Attack.GetType())
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
            transform.transform.localScale = new Vector2(1f /* transform.transform.localScale.x*/, 1f /* transform.transform.localScale.y*/);
            right = true;
            //Debug.Log("Flipping right in nav");
        }
        else if (force.x <= -0.01f)
        {
            transform.transform.localScale = new Vector2(-1f /* transform.transform.localScale.x*/, 1f /* transform.transform.localScale.y*/);
            right = false;
            //Debug.Log("Flipping left in nav");
        }
    }

    public void BypassTarget() 
    {
        Vector2 modPos = new Vector2(this.transform.position.x, this.transform.position.y - 1);
        LayerMask mask = ~((1 << 7) | (1 << 8));
        if (right)
        {
            RaycastHit2D hit = Physics2D.Raycast(modPos, new Vector2(bypassDist, 0), bypassDist, mask);
            if(hit.collider != null && !hit.collider.isTrigger && hit.collider.tag != "Player")
            {
                //float dist = Vector2.Distance(this.transform.position, hit.transform.position);
                float dist = this.transform.position.x - hit.point.x;
                target = new Vector2(this.transform.position.x + (Mathf.Abs(dist) - 2), this.transform.position.y);
                bypass = true;

                //Debug.Log("Moving right to dist of " + dist.ToString() + " after hitting " + hit.collider.name);
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

                    //Debug.Log("Moving right at full distance");
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

                //Debug.Log("Moving left to a dist of " + dist.ToString() + " after hitting " + hit.collider.name);
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

                    //Debug.Log("Moving left at full distance");
                    return;
                }
            }
        }
        //Debug.Log("Could not find suitble point in direction looked");
        //bypass = true;
    }


    public bool getEOP()
    {
        return reachedEOP;
    }

    public void StartPath(Rigidbody2D rigid, Transform targ)
    {
        seeker.StartPath(rigid.position, targ.position, OnPathComplete);
    }

    public void FacePlayer()
    {
        float dist = player.transform.position.x - transform.position.x;
        SwapGFX(new Vector2(dist, 0));
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

    #endregion
}
