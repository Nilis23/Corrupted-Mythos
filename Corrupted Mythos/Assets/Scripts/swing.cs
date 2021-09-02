using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swing : MonoBehaviour
{
    private int damage;
    public EnemyHealth script;



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            Debug.Log("hit");
            //damage enemy
            /*
            script = other.GetComponent<enemyhealth>();
            script.minusHealth(damage);
            */
        }

    }
}
