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

    Transform target;

    float life;

    // Start is called before the first frame update
    void Start()
    {
        life = 10f;
        target = GameObject.Find("Target").transform;

        Invoke("activateCol", 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.MoveTowards(transform.position, target.position, step);

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
        life = 5f;
    }
}
