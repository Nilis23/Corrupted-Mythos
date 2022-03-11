using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public int damage;
    private float time;
    public PlayerHealth script;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("start hurt");
            script = collision.gameObject.GetComponent<PlayerHealth>();
            time = 1f;
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            time += Time.deltaTime;

            if (time >= 1f)
            {
                Debug.Log("hurting" + damage);
                script.minusHealth(damage);
                time = 0;
            }
        }       
    }
}
