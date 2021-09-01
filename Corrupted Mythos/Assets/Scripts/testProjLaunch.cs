using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testProjLaunch : MonoBehaviour
{
    projectileManager manager;
    GameObject targ;

    // Start is called before the first frame update
    void Start()
    {
        targ = GameObject.Find("Target");
        manager = this.GetComponent<projectileManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = ((this.transform.position - targ.transform.position).normalized) * -1;
        Ray ray = new Ray(this.transform.position, dir);
        Debug.DrawRay(this.transform.position, dir);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject == targ)
            {
                manager.attemptProjectileLaunch(this.gameObject);
            }
        }
    }
}
