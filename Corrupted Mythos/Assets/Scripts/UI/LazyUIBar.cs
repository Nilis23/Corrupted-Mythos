using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class LazyUIBar : MonoBehaviour
{
    public float maxHP = 100;
    private float currHP, currHPSlow;
    public float damage = 100;
    public Image barFast, barSlow;
    bool reversed;

    // Update is called once per frame
    float t = 0;
    void Update()
    {
        //interpolating slowHP and currentHP inf unequal
        if (currHPSlow != currHP)
        {
            if (!reversed)
            {
                currHPSlow = Mathf.Lerp(currHPSlow, currHP, t);
                t += 0.5f * Time.deltaTime;
            }
            else
            {
                currHP = Mathf.Lerp(currHP, currHPSlow, t);
                t += 0.5f * Time.deltaTime;
            }
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
        reversed = false;
    }
    public void loseHP(float num)
    {
        currHP -= num;
        reversed = false;
    }
    public void gainHP(float num)
    {
        //currHP += num;
        currHPSlow += num;
        reversed = true;
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(LazyUIBar))]
public class LazyUIEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GUILayout.Space(10);

        LazyUIBar myScript = (LazyUIBar)target;
        if (GUILayout.Button("Fill Bar"))
        {
            myScript.gainHP(100);
        }
    }
}
#endif

