using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseController : MonoBehaviour
{
    [SerializeField]
    Material mat;

    int pID;
    float t = 0;

    // Start is called before the first frame update
    void Start()
    {
        Shader shader = mat.shader;
        pID = Shader.PropertyToID("TVal");
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        mat.SetFloat(pID, t);

        if (t >= 1)
        {
            Destroy(gameObject);
        }
    }
}
