using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Axe", menuName = "Artifacts/Axe", order = 1)]
public class Axe : Artifact
{
    [SerializeField]
    GameObject axPref;
    bool canLaunch; //Add conditions in for this later, find a way to handle launching either in here or to do it from loadout manager
    public override void doAction(GameObject caller)
    {
        canLaunch = true;
        Debug.Log("Launching Proj");
        if (canLaunch)
        {
            Debug.Log("Hello");
            GameObject newAxe = Instantiate(axPref);
            newAxe.transform.position = caller.transform.position;
            if(caller.transform.localScale.x < 0)
            {
                newAxe.transform.localScale = new Vector2((newAxe.transform.localScale.x * -1), newAxe.transform.localScale.y);
            }
        }
    }
}
