using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Spawner", menuName = "Enemy Spawner", order = 0)]
public class EnemySpawner : ScriptableObject
{
    [SerializeField]
    GameObject EnemyPref;
    [SerializeField]
    GameObject miniEnemyPref;
    [SerializeField]
    string spawnerTag;
    [SerializeField]
    float sTimer;
    //public GameObject bar;

    GameObject[] SpawnPoints;

    public void InitSpawner()
    {
        SpawnPoints = GameObject.FindGameObjectsWithTag(spawnerTag);
    }

    public void Spawn(CorruptedNode node, GameObject bar)
    {
        int point = Random.Range(0, SpawnPoints.Length);
        float xmod = Random.Range(0.5f, 1.5f);
        if (Random.value < 0.5)
        {
            xmod *= -1;
        }

        GameObject es = Instantiate(EnemyPref);
        es.GetComponent<AbomHealth>().NodeBerserkBarLocator = bar;
        Debug.Log("spawner called");
        

        Vector2 sp = SpawnPoints[point].transform.position;
        es.transform.position = new Vector2(sp.x + xmod, sp.y);

        es.GetComponent<StateManager>()?.setStgr(sTimer);

        node.addEnemy(es);
        es.GetComponent<ArenaDeathHelper>().SetArena(node);
    }

    public void miniSpawn(MiniNode node, GameObject spawn)
    {
        //Debug.Log("started");
        //int point = Random.Range(0, SpawnPoints.Length);
        float xmod = Random.Range(0.5f, 1.5f);
        if (Random.value < 0.5)
        {
            xmod *= -1;
        }
        
        GameObject es = Instantiate(miniEnemyPref);
        es.transform.position = spawn.transform.position;

        //Vector2 sp = SpawnPoints[point].transform.position;
        //Vector2 sp = this.
        //es.transform.position = new Vector2(sp.x + xmod, sp.y);

        es.GetComponent<StateManager>()?.setStgr(sTimer);

        node.addEnemy(es);
        //Debug.Log(node.name);
        es.GetComponent<MiniArenaDeathHelper>().SetArena(node);
        //Debug.Log("finished");
    }
}
