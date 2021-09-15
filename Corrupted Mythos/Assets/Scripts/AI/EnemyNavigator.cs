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
        Vector2 force = dir * speed * Time.deltaTime;
        rb.AddForce(force);

        float dist = Vector2.Distance(rb.position, path.vectorPath[currentWP]);
        if(dist < nWaypointDistance)
        {
            currentWP++;
        }

        if (force.x >= 0.01f)
        {
            gfx.localScale = new Vector2(1f, 1f);
        }
        else if (force.x <= -0.01f)
        {
            gfx.localScale = new Vector2(-1f, 1f);
        }
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
