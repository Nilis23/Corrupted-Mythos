using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    //private int hpGain = 10;
    public PlayerHealth script;
    private GameObject pickUp;

    private void OnEnable()
    {
        pickUp = this.gameObject.transform.GetChild(0).gameObject;
        pickUp.SetActive(false);
        pickUp.transform.position = this.transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            script = collision.gameObject.GetComponent<PlayerHealth>();
            script.hpGainItems++;

            Debug.Log("food debug start");
            pickUp.SetActive(true);
            StartCoroutine(Wait());
            Debug.Log("food debug done");

            Destroy(gameObject);
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        pickUp.SetActive(false);
    }
}
