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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("One");
            one.doAction();
        }
        if (Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("Two");
            two.doAction();

        }
        if (Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("Three");
            three.doAction();
        }
    }
}
