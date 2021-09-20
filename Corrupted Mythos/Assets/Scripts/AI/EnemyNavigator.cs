using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyNavigator : MonoBehaviour
{
    public GameObject target;

    public float speed = 1;
    public float nWaypointDistance = 3f;

    public Transform gfx;

    private Path path;
    int currentWP;
    bool reachedEOP = false;

    Seeker seeker;
    Rigidbody2D rb;

    float t = 0;

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
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

        Vector2 dir = ((Vector2)path.vectorPath[currentWP] - rb.position).normalized;
        Vector2 force = dir * (speed * Time.fixedDeltaTime);
        //rb.AddForce(force);
        rb.velocity += new Vector2(force.x, 0);

        if(t > 10)
        {
            Debug.Log("WP: " + currentWP.ToString() + " EndWP: " + path.vectorPath.Count.ToString() + " Force: " + force.ToString() + " RB Vel: " + rb.velocity.ToString() + " X Dir: " + dir.x.ToString() + " Speed: " + speed + " Reached EOP: " + reachedEOP.ToString());
            t = 9;
        }


        float dist = Vector2.Distance(rb.position, path.vectorPath[currentWP]);
        if(dist < nWaypointDistance)
        {
            currentWP++;
            t = 0;
        }

        if (rb.velocity.x >= 0.01f)
        {
            gfx.localScale = new Vector2(1f, 1f);
        }
        else if (rb.velocity.x <= -0.01f)
        {
            gfx.localScale = new Vector2(-1f, 1f);
        }

        t += Time.deltaTime;
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            reachedEOP = false;
            currentWP = 0;
        }
    }

    public bool getEOP()
    {
        return reachedEOP;
    }

    public void StartPath(Rigidbody2D rigid, Transform targ)
    {
        seeker.StartPath(rigid.position, targ.position, OnPathComplete);
    }
}
