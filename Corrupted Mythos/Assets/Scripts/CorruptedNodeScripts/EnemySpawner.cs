using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Spawner", menuName = "Enemy Spawner", order = 0)]
public class EnemySpawner : ScriptableObject
{
    [SerializeField]
    GameObject EnemyPref;
    [SerializeField]
    string spawnerTag;

    GameObject[] SpawnPoints;

    public void InitSpawner()
    {
        SpawnPoints = GameObject.FindGameObjectsWithTag(spawnerTag);
    }

    public GameObject Spawn()
    {
        int point = Random.Range(0, SpawnPoints.Length);
        GameObject es = Instantiate(EnemyPref);
        es.transform.position = SpawnPoints[point].transform.position;

        return es;
    }
}
