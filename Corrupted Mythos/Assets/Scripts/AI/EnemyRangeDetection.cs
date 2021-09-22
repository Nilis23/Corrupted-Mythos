using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeDetection : MonoBehaviour
{
    [SerializeField]
    StateManager em;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            em.collisions++;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            em.collisions--;
        }
    }
}
