using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerserkGiver : MonoBehaviour
{
    private PlayerHealth script;

    private void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            script = collision.gameObject.GetComponent<PlayerHealth>();
            script.FillBerserk();
            this.gameObject.SetActive(false);
            Destroy(this);
        }
    }
}
