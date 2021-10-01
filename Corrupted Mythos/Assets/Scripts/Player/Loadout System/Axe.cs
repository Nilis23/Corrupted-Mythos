using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Axe", menuName = "Artifacts/Axe", order = 1)]
public class Axe : Artifact
{
    [SerializeField]
    GameObject axPref;

    public override void doAction(GameObject caller)
    {
        GameObject newAxe = Instantiate(axPref);
        newAxe.transform.position = caller.transform.position;
        if (caller.transform.localScale.x < 0)
        {
            newAxe.transform.localScale = new Vector2((newAxe.transform.localScale.x * -1), newAxe.transform.localScale.y);
        }
    }

}
