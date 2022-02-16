using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GodBarControl : MonoBehaviour
{
    [SerializeField]
    Image Bar;
    [SerializeField]
    float barstart;
    [SerializeField]
    float barfull;
    float t = 0;

    // Start is called before the first frame update
    void Start()
    {
        barstart = 1;
        Bar.rectTransform.sizeDelta = new Vector2(barstart, 33.081f);
    }

    /*
    // Update is called once per frame
    void Update()
    {
        if (t >= 1)
        {
            barstart += 1;
            Bar.rectTransform.sizeDelta = new Vector2(barstart, 33.081f);
            t = 0;
        }
        t += Time.deltaTime;
    }
    */
    
    public void IncrementBar(float valAdd)
    {
        barstart += valAdd;
        Bar.rectTransform.sizeDelta = new Vector2(barstart, 33.081f);
    }

    public void ResetBar()
    {
        barstart = 0;
        Bar.rectTransform.sizeDelta = new Vector2(barstart, 33.081f);
    }
}
