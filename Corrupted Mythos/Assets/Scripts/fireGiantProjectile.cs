using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireGiantProjectile : MonoBehaviour
{
    [SerializeField]
    MeshRenderer myMesh;
    [SerializeField]
    SphereCollider myCol;
    [SerializeField]
    float step;
    Vector3 dir;

    float life;

    // Start is called before the first frame update
    void Start()
    {
        life = 10f;

        dir = (GameObject.FindGameObjectWithTag("Player").transform.position - this.transform.position).normalized;
        //this.gameObject.transform.position = dir * 1;

        Invoke("activateCol", 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        this.transform.Translate(dir * Time.deltaTime * step);
        //this.GetComponent<Rigidbody>().AddForce(dir * step);

        if(life > 0)
        {
            life -= Time.deltaTime;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void activateCol()
    {
        myCol.enabled = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //myMesh.enabled = false;
        //step = 0;
        life = 5f;
    }
}
