using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorruptedNode : MonoBehaviour
{
    #region Serialized Fields
    [Tooltip("This is the list of enemies this node can spawn")]
    [SerializeField]
    List<EnemySpawner> EnemyList = new List<EnemySpawner>();
    [Tooltip("The list of barriers to activate when the arena goes live")]
    [SerializeField]
    List<GameObject> BarrierList = new List<GameObject>();
    [Tooltip("The list of spawnpoints attached to this node")]
    [SerializeField]
    List<GameObject> Spawners = new List<GameObject>();
    [Space]
    [Tooltip("The number of spawns")]
    [SerializeField]
    int SpawnCount;
    [Tooltip("The time between spawns")]
    [SerializeField]
    float tMax;
    [Tooltip("The initial wave")]
    [SerializeField]
    int initWave;

    [Space]
    [SerializeField]
    bool ManualStart;
    #endregion

    //Internal variables
    int spawned = 0;
    float t;
    bool active = false;
    List<GameObject> Enemies = new List<GameObject>();
    private Inputs pcontroller;

    // Start is called before the first frame update
    void Start()
    {
        if(EnemyList.Count == 0)
        {
            Debug.LogError("No enemies to spawn. They should be assigned in the editor.");
        }
        pcontroller = new Inputs();
        pcontroller.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (ManualStart)
        {
            StartNodeActivity();
            ManualStart = false;
        }
        if (active)
        {
            t += Time.deltaTime;

            if(t >= tMax && spawned < SpawnCount)
            {
                SpawnEnemy();
            }

            if(Enemies.Count == 0 && spawned == SpawnCount)
            {
                EndNodeActivity();
            }

            for(int i = 0; i < Enemies.Count; i++)
            {
                if(Enemies[i] == null) 
                {
                    Enemies.RemoveAt(i);
                }
            }
        }   
    }

    #region NodeActivity
    public void StartNodeActivity()
    {
        foreach(GameObject barrier in BarrierList)
        {
            barrier.SetActive(true);
        }

        foreach(GameObject spawner in Spawners)
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

        t = 0;
        active = true;
    }

    public void SpawnEnemy()
    {
        int pick = Random.Range(0, EnemyList.Count);

        Enemies.Add(EnemyList[pick].Spawn());
        spawned++;

        t = 0;
    }

    public void EndNodeActivity()
    {
        foreach (GameObject barrier in BarrierList)
        {
            barrier.SetActive(false);
        }

        //Temporary, eventually there will be an effect here and an invoked destroy
        Destroy(this.gameObject);
    }
    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Spot where we could do a prompt for what button to press

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (pcontroller.player.ArtifactInteract.triggered)
        {
            StartNodeActivity();
        }
    }
}
