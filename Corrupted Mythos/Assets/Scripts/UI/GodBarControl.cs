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
    
    public void IncrementBar(float valAdd)
    {
        barstart += valAdd;
        if(barstart > barfull)
        {
            barstart = barfull;
        }
        Bar.rectTransform.sizeDelta = new Vector2(barstart, 33.081f);
    }

    public void ResetBar()
    {
        barstart = 1;
        Bar.rectTransform.sizeDelta = new Vector2(barstart, 33.081f);
    }

    //This allows other scripts to query what size the full bar should be for calculating how much to fill it in each instance
    public float GetFullSize()
    {
        return barfull;
    }
}
