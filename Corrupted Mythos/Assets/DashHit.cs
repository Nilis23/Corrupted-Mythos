using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashHit : MonoBehaviour
{
    [SerializeField]
    int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy") && !collision.isTrigger)
        {
            collision.GetComponent<EnemyHealth>()?.minusHealth(damage, false);
            Debug.Log("Hit enemy with dash");
        }
    }
}
