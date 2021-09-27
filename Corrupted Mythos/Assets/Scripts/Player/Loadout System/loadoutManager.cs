using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadoutManager : MonoBehaviour
{
    [SerializeField]
    Artifact one;
    [SerializeField]
    Artifact two;
    [SerializeField]
    Artifact three;

    private Inputs pcontroller;

    // Start is called before the first frame update
    void Start()
    {
        pcontroller = new Inputs();
        pcontroller.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        //This code doesn't work, needs input manager

        if(pcontroller.player.ArtifactOne.triggered && one != null)
        {
            one.doAction(this.gameObject);
        }
        if(pcontroller.player.ArtifactTwo.triggered && two != null)
        {
            two.doAction(this.gameObject);
        }
        if (pcontroller.player.ArtifactThree.triggered && three != null)
        {
            three.doAction(this.gameObject);
        }
    }
}
