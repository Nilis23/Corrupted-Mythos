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
        Debug.Log("hello");
        myanim.SetTrigger("Slam");
        t = 0.1f;
    }

    private void Update()
    {
        t -= Time.deltaTime;
        if(t < 0)
        {
            if (myanim.GetCurrentAnimatorStateInfo(0).IsName("SlamLandIdle"))
            {
                gameObject.SetActive(false);
            }
        }
    }
}
