using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wispParticles : MonoBehaviour
{
    public GameObject player;
    private GameObject end;
    private float speed = 5f;

    private void Start()
    {
        end = player.transform.GetChild(5).gameObject;
        end.transform.position = new Vector3(end.transform.position.x, end.transform.position.y, this.transform.position.z);
    }

    private void OnEnable()
    {
        StartCoroutine(holdup());
    }

    private void Update()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, end.transform.position, Time.deltaTime*speed);
    }

    IEnumerator holdup()
    {
        yield return new WaitForSeconds(1);
        this.gameObject.SetActive(false);
    }
}
