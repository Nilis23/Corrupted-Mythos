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

    int tID;
    int sID;
    float t = 0;

    // Start is called before the first frame update
    void Start()
    {
        tID = Shader.PropertyToID("_TVal");
        sID = Shader.PropertyToID("_Speed");
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        ///mat.SetFloat(pID, t);

        sr.material.SetFloat(tID, t);

        Debug.Log(t * sr.material.GetFloat(sID));
        if((t * sr.material.GetFloat(sID)) >= 0.8)
        {
            Destroy(gameObject);
        }
    }
}
