using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PulseController : MonoBehaviour
{
    [SerializeField]
    Material mat;
    [SerializeField]
    SpriteRenderer sr;

    int pID;
    float t = 0;

    // Start is called before the first frame update
    void Start()
    {
        pID = Shader.PropertyToID("_TVal");
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        ///mat.SetFloat(pID, t);

        sr.material.SetFloat(pID, t);
        Debug.Log(sr.material.GetFloat(pID));
    }
}
