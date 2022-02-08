using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wispParticles : MonoBehaviour
{
    private Vector2 endloc;
    private float speed = 10;
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
            rate += Time.deltaTime * .3f;
            rate = Mathf.Clamp(rate, 0, 1);
            transform.localScale = Vector3.Slerp(origScale, Vector3.zero, rate);
        }

        this.gameObject.SetActive(false);
        Destroy(this);
    }

    public void end(GameObject location)
    {
        if(location != null)
        {
            endloc = location.transform.position; 
        }
    }
}
