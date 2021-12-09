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
    [Space]
    [SerializeField]
    ImageController axe;
    [SerializeField]
    ImageController horn;

    private Inputs pcontroller;
    private float[] timers = new float[3];

    // Start is called before the first frame update
    void Start()
    {
        pcontroller = new Inputs();
        pcontroller.Enable();

        for(int i = 0; i < timers.Length; i++)
        {
            timers[i] = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //This code doesn't work, needs input manager

        if(pcontroller.player.ArtifactOne.triggered && one != null && timers[0] <= 0)
        {
            one.doAction(this.gameObject);
            timers[0] = one.getTimer();
            axe.DeactivateImage();
        }
        if(pcontroller.player.ArtifactTwo.triggered && two != null && timers[1] <= 0)
        {
            two.doAction(this.gameObject);
            timers[1] = two.getTimer();
            horn.DeactivateImage();
        }
        if (pcontroller.player.ArtifactThree.triggered && three != null && timers[2] <= 0)
        {
            three.doAction(this.gameObject);
            timers[2] = three.getTimer();
        }

        for(int i = 0; i < timers.Length; i++)
        {
            timers[i] -= Time.deltaTime;
            if(i == 0 && timers[i] <= 0)
            {
                axe.ActivateImage();
            }
            if(i == 1 && timers[i] <= 0 && horn != null)
            {
                horn.ActivateImage();
            }
        }
    }
}
