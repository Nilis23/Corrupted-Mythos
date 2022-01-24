using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wispParticles : MonoBehaviour
{
    public GameObject end;
    private bool on=false;
    private float speed = 5f;

    private void Start()
    {
        end.transform.position = new Vector3(end.transform.position.x, end.transform.position.y, this.transform.position.z);
    }

    private void Update()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, end.transform.position, Time.deltaTime*speed);
    }

    IEnumerator holdup()
    {
        yield return new WaitForSeconds(.5f);
    }
}
