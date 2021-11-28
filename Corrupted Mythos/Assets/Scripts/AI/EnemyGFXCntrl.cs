using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGFXCntrl : MonoBehaviour
{
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.velocity.x >= 0.01f)
        {
            transform.localScale = new Vector2(1f, 1f);
            Debug.Log("Flipping right in cntrl");
        }
        else if(rb.velocity.x <= -0.01f)
        {
            transform.localScale = new Vector2(-1f, 1f);
            Debug.Log("Flipping left in cntrl");
        }
    }
}
