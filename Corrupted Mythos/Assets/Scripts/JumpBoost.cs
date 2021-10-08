using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoost : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("boostio");
            collision.gameObject.GetComponent<CharacterController2D>().m_JumpForce = 1000f;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("unboostio");
            collision.gameObject.GetComponent<CharacterController2D>().m_JumpForce = 700;
        }
    }
}
