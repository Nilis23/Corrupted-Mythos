using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public int damage;
    private PlayerHealth script;
    public bool flip;
    public GameObject OtherSideHit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            script = collision.gameObject.GetComponent<PlayerHealth>();
            script.minusHealth(damage);
            script.knockAround(flip);
            StartCoroutine(IFrames());
        }
    }

    IEnumerator IFrames()
    {
        OtherSideHit.GetComponent<PolygonCollider2D>().enabled = false;
        this.GetComponent<PolygonCollider2D>().enabled = false;
        yield return new WaitForSeconds(1);
        OtherSideHit.GetComponent<PolygonCollider2D>().enabled = true;
        this.GetComponent<PolygonCollider2D>().enabled = true;
    }
}
