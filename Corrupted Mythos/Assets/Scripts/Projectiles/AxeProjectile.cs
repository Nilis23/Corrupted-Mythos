using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeProjectile : MonoBehaviour
{
    [SerializeField]
    float launchForce;
    [SerializeField]
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        if(this.transform.localScale.x > 0)
        {
            Vector2 force = new Vector2(launchForce / 2, launchForce / 2);
            rb.AddForce(force);
        }
        else
        {
            Vector2 force = new Vector2((launchForce / 2) * -1, launchForce / 2);
            rb.AddForce(force);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
