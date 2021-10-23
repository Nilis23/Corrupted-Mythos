using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeEndBehavior : MonoBehaviour
{
    [SerializeField]
    float tMax;
    [SerializeField]
    GameObject Effect1;
    [SerializeField]
    GameObject Effect2;

    private void Start()
    {
        Invoke("SwapEffects", tMax - 0.8f);
        Destroy(gameObject, tMax);
    }

    void SwapEffects()
    {
        Effect1.SetActive(false);
        Effect2.SetActive(true);
    }
}
