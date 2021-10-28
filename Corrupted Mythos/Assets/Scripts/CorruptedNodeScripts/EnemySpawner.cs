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
    [SerializeField]
    float sTimer;

    GameObject[] SpawnPoints;

    public void InitSpawner()
    {
        SpawnPoints = GameObject.FindGameObjectsWithTag(spawnerTag);
    }

    public void Spawn(CorruptedNode node)
    {
        int point = Random.Range(0, SpawnPoints.Length);
        float xmod = Random.Range(0.5f, 1.5f);
        if (Random.value < 0.5)
        {
            xmod *= -1;
        }

        GameObject es = Instantiate(EnemyPref);

        Vector2 sp = SpawnPoints[point].transform.position;
        es.transform.position = new Vector2(sp.x + xmod, sp.y);

        es.GetComponent<StateManager>()?.setStgr(sTimer);

        node.addEnemy(es);
        es.GetComponent<ArenaDeathHelper>().SetArena(node);
    }
}
