using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LazyUIBar : MonoBehaviour
{
    public float maxHP = 100;
    private float currHP, currHPSlow;
    public float damage = 100;
    public Image barFast, barSlow;

    // Update is called once per frame
    float t = 0;
    void Update()
    {
        //interpolating slowHP and currentHP inf unequal
        if (currHPSlow != currHP)
        {
            currHPSlow = Mathf.Lerp(currHPSlow, currHP, t);
            t += 0.5f * Time.deltaTime;
        }
        else
        {
            t = 0;
            //resetting interpolator
        }

        //Setting fill amount
        barFast.fillAmount = currHP / maxHP;
        barSlow.fillAmount = currHPSlow / maxHP;
    }

    public void setCurHP(float hp)
    {
        currHP = hp;
        currHPSlow = hp;
    }
    public void loseHP(float num)
    {
        currHP -= num;
    }
    public void gainHP(float num)
    {
        currHP += num;
        currHPSlow += num;
    }
}
