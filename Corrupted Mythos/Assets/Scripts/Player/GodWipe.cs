using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodWipe : MonoBehaviour
{
    private float rate;
    private Vector3 OrginScale;
    private Vector3 EndScale;

    private void Start()
    {
        OrginScale = this.transform.localScale;
        StartCoroutine(growth());
        EndScale = new Vector3(40, 40, 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.CompareTag("enemy"))
        {
            Debug.Log("die");
            collision.GetComponent<EnemyHealth>()?.takeDamage(1000);
        }
    }

    IEnumerator growth()
    {
        while (transform.localScale.x != EndScale.x)
        {
            yield return null;
            rate += Time.deltaTime * .5f;
            rate = Mathf.Clamp(rate, 0, 1);
            transform.localScale = Vector3.Lerp(OrginScale, EndScale, rate);
        }
        this.gameObject.SetActive(false);
    }
}
