using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileManager : MonoBehaviour
{
    [Space]
    [Tooltip("The prefab from which the projectile will be instantiated")]
    [SerializeField]GameObject projPref;
    [SerializeField]
    float tmax;
    float timer = 0f;

    // Update is called once per frame
    void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    public void attemptProjectileLaunch(GameObject launcher)
    {
        if(timer <= 0)
        {
            Vector2 dir = (GameObject.FindGameObjectWithTag("Player").transform.position - launcher.transform.position).normalized;
            if(dir.x > 0)
            {
                Vector2 start = launcher.transform.position;
                start.x = start.x + 1f;
                GameObject newProj = Instantiate(projPref, start, Quaternion.identity);
                newProj.GetComponent<fireGiantProjectile>().origin = gameObject.transform.position;
            }
            else
            {
                Vector2 start = launcher.transform.position;
                start.x = start.x - 1f;
                GameObject newProj = Instantiate(projPref, start, Quaternion.identity);
                newProj.GetComponent<fireGiantProjectile>().origin = gameObject.transform.position;
            }
            
            //Rigidbody projRB = newProj.GetComponent<Rigidbody>();

            timer = tmax;
        }
    }
}
