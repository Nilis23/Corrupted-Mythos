using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoost : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("boostio");
            collision.gameObject.GetComponent<CharacterController2D>().m_JumpForce = 1000f;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("unboostio");
            collision.gameObject.GetComponent<CharacterController2D>().m_JumpForce = 400f;
        }
    }
}
