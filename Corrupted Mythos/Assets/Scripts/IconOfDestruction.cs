using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconOfDestruction : MonoBehaviour
{
    public PlayerMovement movement;
    public ParticleSystem effect;
    public List<GameObject> enemies = new List<GameObject>();

    private void Start()
    {
        if (enemies.Count == 0)
        {
            Debug.Log("assign enemies to list");
        }
    }

    private void Update()
    {
        if (enemies.Count==0)
        {
            movement.killCount += 15;
            effect.Play();
        }
    }
}
