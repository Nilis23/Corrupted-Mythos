using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public int damage;
    public int knockup;
    private PlayerHealth script;
    public bool flip;
    public GameObject OtherSideHit;
    CameraShake camshake;

    private void Awake()
    {
        camshake = GameObject.FindObjectOfType<CameraShake>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            script = collision.gameObject.GetComponent<PlayerHealth>();
            script.block = false;
            bool dash = collision.gameObject.GetComponent<PlayerMovement>().isDash;
            if (!dash)
            {
                script.minusHealth(damage, false);
                camshake.shakeCam(3, 0.2f, true);
                script.knockAround(flip, knockup);
                StartCoroutine(IFrames());
                GameObject.FindObjectOfType<CameraShake>().shakeCam(10, 0.2f, true);
            }
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
