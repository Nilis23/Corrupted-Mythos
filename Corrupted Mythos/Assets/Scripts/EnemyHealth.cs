using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    public int health;
    public Transform enemy;
    void Update()
    {
        if (health<=0)
        {
            enemy.gameObject.SetActive(false);
        }
    }

    public void minusHealth(int damage)
    {
        health -= damage;
    }
    public void addHealth(int gain)
    {
        health += gain;
    }
}
