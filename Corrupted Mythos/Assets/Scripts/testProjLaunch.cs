using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testProjLaunch : MonoBehaviour
{
    projectileManager manager;
    GameObject targ;
    [SerializeField]Material hitmat;

    // Start is called before the first frame update
    void Start()
    {
        targ = GameObject.FindGameObjectWithTag("Player");
        manager = this.GetComponent<projectileManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = (targ.transform.position - this.transform.position).normalized;
        Ray ray = new Ray(this.transform.position, dir);
        Debug.DrawRay(this.transform.position, dir * 20f);

        bool hit = Physics.Raycast(ray, out RaycastHit rayHit);

        if (hit)
        {
            rayHit.collider.GetComponent<Renderer>().material.color = Color.red;
            if(rayHit.collider.gameObject == targ)
            {
                manager.attemptProjectileLaunch(this.gameObject);
            }
        }
    }
}
