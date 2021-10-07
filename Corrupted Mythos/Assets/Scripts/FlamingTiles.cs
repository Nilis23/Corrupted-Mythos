using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamingTiles : MonoBehaviour
{

    public int damage = 20;
    private float time;
    private bool flaming=false;
    public PlayerHealth script;

    /*
        private void Update()
        {
            if (flaming)
            {
                time += Time.deltaTime;
                //Debug.Log(time);
            }

            if (time>=1f)
            {
                script.minusHealth(damage);
                time = 0;
            }
        }
*/
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            script = collision.gameObject.GetComponent<PlayerHealth>();
            time = 1f;
            //flaming = true;
            //Debug.Log(flaming);
        }
    }
        
            
        
/*
        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                script = collision.gameObject.GetComponent<PlayerHealth>();
                time = 0f;
                flaming = false;
                Debug.Log(flaming);
            }

        }*/

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            time += Time.deltaTime;

            if (time >= 1f)
            {
                script.minusHealth(damage);
                time = 0;
            }
        }
    }
}
