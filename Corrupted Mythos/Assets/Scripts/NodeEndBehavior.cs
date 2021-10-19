using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeEndBehavior : MonoBehaviour
{
    [SerializeField]
    float tMax;

    private void Start()
    {
        Destroy(gameObject, tMax);
    }
}
