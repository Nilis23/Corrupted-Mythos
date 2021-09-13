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
        Debug.Log(health);
    }
    public void addHealth(int gain)
    {
        health += gain;
        Debug.Log(health);
    }
}
