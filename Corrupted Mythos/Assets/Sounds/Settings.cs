using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public static Settings instance;

    public float vol = 1;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
            return;
        }
    }

    public void SetVolVal(float value)
    {
        Debug.Log("Setting value");
        vol = value;
    }
}
