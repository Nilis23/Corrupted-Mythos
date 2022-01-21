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
            Debug.Log("assign enemies to list");
        }

        for (count=0; count < enemies.Count; count++)
        {
            Debug.Log(count);
        }

        lit.transform.position = this.transform.position;
        lit.SetActive(false);
    }

    private void Update()
    {

        if (count == 0)
        {
            effect.Play();
            movement.killCount += 15;
            StartCoroutine(destroyThis());
            count -= 1;
        }
    }

    IEnumerator destroyThis()
    {
        yield return new WaitForSeconds(1);
        lit.SetActive(true);
        Destroy(this);
    }
}
