using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndHandler : MonoBehaviour
{
    List<CorruptedNode> Nodes = new List<CorruptedNode>();
    bool lvlFin = false;
    bool done = false;

    [SerializeField]
    GameObject lvlEndObj;

    AudioManager manager;

    private void Start()
    {
        manager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lvlFin && !done)
        {
            //end the level
            lvlEndObj.SetActive(true);
            manager.PlaySound("lvlFin");
            done = true;
        }
    }

    public bool AddToList(CorruptedNode node)
    {
        Nodes.Add(node);
        if (Nodes.Contains(node))
        {
            return true;
        }
        return false;
    }

    public void RemoveFromList(CorruptedNode node)
    {
        Nodes.Remove(node);
        if(Nodes.Count == 0)
        {
            lvlFin = true;
        }
    }
}
