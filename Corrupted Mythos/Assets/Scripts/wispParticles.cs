using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wispParticles : MonoBehaviour
{
    public GameObject berserkBar;
    private Vector2 endloc;
    private float speed = 5;
    PlayerMovement player;

    private void Start()
    {

        Debug.Log(berserkBar);
        player = FindObjectOfType<PlayerMovement>();
        endloc = player.beserkLocator.transform.position;
        //end.transform.position = new Vector3(end.transform.position.x, end.transform.position.y, this.transform.position.z);
    }

    private void OnEnable()
    {
        StartCoroutine(holdup());
        //endloc = GameObject.Find("beserkLocator").transform.position;
    }

    private void Update()
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position, endloc, Time.deltaTime*speed);
        //this.transform.localScale += new Vector3(-.1f, -.1f, 0);
    }

    IEnumerator holdup()
    {
        yield return new WaitForSeconds(2);
        this.gameObject.SetActive(false);
        Destroy(this);
    }
}
