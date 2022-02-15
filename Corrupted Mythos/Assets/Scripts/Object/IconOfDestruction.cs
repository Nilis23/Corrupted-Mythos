using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconOfDestruction : MonoBehaviour
{
    public PlayerMovement movement;
    public ParticleSystem effect;
    public List<GameObject> enemies = new List<GameObject>();
    public GameObject lit;
    public int count;

    private void Start()
    {
        if (enemies.Count == 0)
        {
           // Debug.Log("assign enemies to list");
        }

        for (count=0; count < enemies.Count; count++)
        {
            //Debug.Log(count);
            //Couldn't count just be directly set rather than using a loop?
        }
        count = enemies.Count;

        lit.SetActive(false);
    }

    private void Update()
    {

        if (count == 0)
        {
            effect.Play();
            movement.killCount = 15;
            Debug.Log("killcount set to 15");
            StartCoroutine(destroyThis());
            count -= 1;
        }
    }

    IEnumerator destroyThis()
    {
        yield return new WaitForSeconds(1);
        lit.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
