using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingStone : MonoBehaviour
{
    [SerializeField]
    PlayerHealth playerHealth;

    bool Checked;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Checked)
        {
            if (collision.gameObject.tag == "Player" && !collision.isTrigger)
            {

            }
        }
    }
}
