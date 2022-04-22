using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ballista : MonoBehaviour
{
    public PlayerMovement movement;
    public GameObject E;
    public GameObject shotPref;
    public GameObject aim;
    public Inputs CtrlInputs;
    private float rot;
    public float speed = 150;
    private PewPew zoomies;

    public static Action mounted = delegate { };

    private void OnEnable()
    {
        PlayerMovement.shoot += shooting;        
    }
    private void OnDisable()
    {
        PlayerMovement.shoot -= shooting;
    }

    private void Start()
    {
        aim = this.transform.Find("aim").gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            E.SetActive(true);
            movement = collision.GetComponent<PlayerMovement>();
            movement.mountable = true;
            movement.ontop = this.gameObject.GetComponent<Ballista>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            E.SetActive(false);
            movement.mountable = false;
            movement.ontop = null;
            movement = null;
            CtrlInputs = null;
        }
    }

    public void shooting()
    {
        GameObject pew = Instantiate(shotPref);
        zoomies = pew.GetComponent<PewPew>();
        zoomies.target = aim;
        zoomies.cannon = transform;
        pew.gameObject.SetActive(true);
        pew.transform.position = this.transform.position;
    }

    public void strtcore()
    {
        StartCoroutine(rotate());
    }
    IEnumerator rotate()
    {
        float i=0;
        while (movement)
        {
            yield return null;
            rot = CtrlInputs.player.movement.ReadValue<Vector2>().y;
            if (rot>0)
            {
                i += Time.deltaTime * speed;
                this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, i));
            }
             else if (rot<0)
            {
                i -= Time.deltaTime * speed;
                this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, i));
            }
            else {   }
        }
    }
}
