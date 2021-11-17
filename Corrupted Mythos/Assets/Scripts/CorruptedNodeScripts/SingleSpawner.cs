using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleSpawner : MonoBehaviour
{
    public GameObject enemy;

    void Start()
    {
        enemy = Instantiate(enemy);
        enemy.transform.position = this.transform.position;
    }

    void Update()
    {
        if (enemy == null)
        {
            enemy = Instantiate(enemy);
            enemy.transform.position = this.transform.position;
        }
    }
}
