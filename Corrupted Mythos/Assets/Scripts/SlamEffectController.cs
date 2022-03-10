using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlamEffectController : MonoBehaviour
{
    [SerializeField]
    Animator myanim;
    float t;

    private void OnEnable()
    {
        myanim.SetTrigger("Slam");
        t = 0.33f;
    }

    private void Update()
    {
        t -= Time.deltaTime;
        if(t < 0)
        {
            gameObject.SetActive(false);
        }
    }
}
