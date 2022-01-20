using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconOfDestruction : MonoBehaviour
{
    public PlayerMovement movement;
    public ParticleSystem effect;
    public List<GameObject> enemies = new List<GameObject>();
    public int count;

    private void Start()
    {
        if (enemies.Count == 0)
        {
            Debug.Log("assign enemies to list");
        }

        for (count=0;count<enemies.Count;count++)
        {
            Debug.Log(count);
        }
        count++;
    }

    private void Update()
    {

        if (count == 0)
        {
            effect.Play();
            movement.killCount += 15;
        }
    }
}
