using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
    public bool active = false;
    List<GameObject> Enemies = new List<GameObject>();
    private Inputs pcontroller;
    private Transform target;
    private LevelEndHandler leh;
    bool init = false;

    // Start is called before the first frame update
    void Start()
    {
        if(EnemyList.Count == 0)
        {
            Debug.LogError("No enemies to spawn. They should be assigned in the editor.");
        }
        pcontroller = new Inputs();
        pcontroller.Enable();

        leh = GameObject.FindGameObjectWithTag("LevelEndHandler").GetComponent<LevelEndHandler>();
        init = leh.AddToList(this);
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
        EnemyList[pick].Spawn(this);

        spawned++;
        t = 0;
    }

    public void ResetNodeActivity()
    {
        foreach(GameObject enemy in Enemies)
        {
            Destroy(enemy);
        }
        Enemies.Clear();
        spawned = 0;
        t = 0;
        foreach (GameObject barrier in BarrierList)
        {
            barrier.SetActive(false);
        }

        foreach (GameObject spawner in Spawners)
        {
            spawner.SetActive(false);
        }
    }

    public void EndNodeActivity()
    {
        foreach (GameObject barrier in BarrierList)
        {
            barrier.SetActive(false);
        }

        if (init)
        {
            leh.RemoveFromList(this);
        }
        //Temporary, eventually there will be an effect here and an invoked destroy
        Destroy(this.gameObject);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision.GetType() == typeof(BoxCollider2D))
        {
            target = collision.transform;
            pcontroller.player.NodeInteract.started += StartNode;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision.GetType() == typeof(BoxCollider2D))
        {           
            pcontroller.player.NodeInteract.started -= StartNode;       
        }
    }
    private void StartNode(InputAction.CallbackContext c)
    {
        StartNodeActivity();
        target.GetComponent<PlayerHealth>().node = this;
    }
}
