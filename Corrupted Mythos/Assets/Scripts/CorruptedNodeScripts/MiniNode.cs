using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniNode : MonoBehaviour
{
    #region Serialized Fields
    [Tooltip("This is the list of enemies this node can spawn")]
    [SerializeField]
    List<EnemySpawner> EnemyList = new List<EnemySpawner>();
    [Tooltip("The list of spawnpoints attached to this node")]
    [SerializeField]
    List<GameObject> Spawners = new List<GameObject>();
    [Space]
    [Tooltip("The number of spawns")]
    [SerializeField]
    int SpawnCount;
    [Tooltip("The initial wave")]
    [SerializeField]
    int initWave;
    [Tooltip("The rest period for the player")]
    [SerializeField]
    float restT = 2;
    [Tooltip("The size of subsequent waves")]
    [SerializeField]
    int subWaves;

    [Space]
    [SerializeField]
    bool ManualStart;
    #endregion

    //Internal variables
    int spawned = 0;
    public bool active = false;
    List<GameObject> Enemies = new List<GameObject>();
    private Inputs pcontroller;
    private Transform target;
    bool init = false;
    float t = 0;
    bool end = false;
    public PlayerHealth playerHealth;
    private int points = 100;

    // Start is called before the first frame update
    void Start()
    {
        if (EnemyList.Count == 0)
        {
            Debug.LogError("No enemies to spawn. They should be assigned in the editor.");
        }
        pcontroller = new Inputs();
        pcontroller.Enable();

        StartNodeActivity();
    }

    // Update is called once per frame
    void Update()
    {
        if (ManualStart)
        {
            StartNodeActivity();
            ManualStart = false;
        }

        if (active && !end)
        {
            if (Enemies.Count == 0 && spawned >= SpawnCount)
            {
                EndNodeActivity();
                playerHealth.points += points;
                Debug.Log("adding points: node");
                Debug.Log(points);
                playerHealth.pointScore.text = playerHealth.points.ToString();
            }
            else if (Enemies.Count == 0)
            {
                if (t <= 0)
                {
                    for (int i = 0; i < subWaves; i++)
                    {
                        if (spawned < SpawnCount)
                        {
                            SpawnEnemy();
                        }
                    }
                    t = restT;
                    return;
                }
                t -= Time.deltaTime;
            }
        }
    }

    #region NodeActivity
    public void StartNodeActivity()
    {

        foreach (GameObject spawner in Spawners)
        {
            spawner.SetActive(true);
        }

        foreach (EnemySpawner spawner in EnemyList)
        {
            spawner.InitSpawner();
        }

        for (int i = 0; i < initWave; i++)
        {
            SpawnEnemy();
        }

        t = restT;
        active = true;
    }

    public void SpawnEnemy()
    {
        int pick = Random.Range(0, EnemyList.Count);
        EnemyList[pick].miniSpawn(this);

        spawned++;
    }

    public void EndNodeActivity()
    {

        if (!end)
        {
            Destroy(this.gameObject, 3f);
            end = true;
            playerHealth.points += 100;

        }
    }

    public void addEnemy(GameObject enemy)
    {
        Enemies.Add(enemy);
    }

    public void removeEnemy(GameObject enemy)
    {
        if (Enemies.Contains(enemy))
        {
            Enemies.Remove(enemy);
        }
    }
    #endregion
}
