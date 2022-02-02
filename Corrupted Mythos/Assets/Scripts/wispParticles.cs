using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wispParticles : MonoBehaviour
{
    public GameObject berserkBar;
    private Vector2 endloc;
    private float speed = 5;
    PlayerMovement player;
    private float rate;
    private Vector3 origScale;

    private void Start()
    {
        origScale = transform.localScale;
        player = FindObjectOfType<PlayerMovement>();
        endloc = player.beserkLocator.transform.position;
    }

    private void OnEnable()
    {
        StartCoroutine(holdup());
    }

    IEnumerator holdup()
    {
        while (transform.position.x != endloc.x && transform.position.y != endloc.y)
        {
            yield return null;
            transform.position = Vector2.MoveTowards(this.transform.position, endloc, Time.deltaTime * speed);
            rate += Time.deltaTime * .5f;
            rate = Mathf.Clamp(rate, 0, 1);
            transform.localScale = Vector3.Lerp(origScale, Vector3.zero, rate);
        }

        this.gameObject.SetActive(false);
        Destroy(this);
    }
}
