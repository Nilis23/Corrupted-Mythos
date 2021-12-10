using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrolleyCamera : MonoBehaviour
{
    public GameObject endingLocation;
    public int speed;
    public GameObject Pcamera;
    public GameObject Tcamera;
    public GameObject Fcamera;
    private bool go;

    private void Start()
    {
        Tcamera.SetActive(false);
        Fcamera.SetActive(true);
        endingLocation.transform.position = new Vector3(endingLocation.transform.position.x, endingLocation.transform.position.y, Tcamera.transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Pcamera = collision.GetComponent<PlayerHealth>().Pcamera;
            StartCoroutine(camera());
        }
    }
    IEnumerator camera()
    {
        Fcamera.SetActive(true);
        Pcamera.SetActive(false);
        yield return new WaitForSeconds(3);
        Tcamera.SetActive(true);
        Fcamera.SetActive(false);
        yield return new WaitForSeconds(2);
        go = true;
    }

    void Update()
    {
        if (go)
        {
            Tcamera.transform.position = Vector3.MoveTowards(Tcamera.transform.position, endingLocation.transform.position, Time.deltaTime * speed);

            if (endingLocation.transform.position == this.transform.position)
            {
                Pcamera.SetActive(true);
                Tcamera.SetActive(false);
                go = false;
            }
        }
    }

}
