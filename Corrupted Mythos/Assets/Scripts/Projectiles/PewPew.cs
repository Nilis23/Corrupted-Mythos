using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PewPew : MonoBehaviour
{
    public GameObject target;
    public Transform cannon;
    private float speed = 1;
    private Vector3 direction;
    private float dealt;

    private void OnEnable()
    {
        StartCoroutine(zoom());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(" "))
        {
            //hit

            Destroy(this);
            this.gameObject.SetActive(false);
        }
    }

    IEnumerator zoom()
    {
        direction = cannon.right * Time.deltaTime * speed;
        while (dealt <= 10)
        {
            yield return null;
            transform.position += direction;
            dealt += Time.deltaTime;
        }
        Destroy(this);
        this.gameObject.SetActive(false);
    }
}
