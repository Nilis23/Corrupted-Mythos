using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public abstract class NavBase : MonoBehaviour
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

    #region A*_Storage

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
