using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IoDAbomHealth : MonoBehaviour
{
    public OWAbomHealth health;
    public IconOfDestruction icon;

    private void Start()
    {
        health = this.GetComponent<OWAbomHealth>();    
    }

    public void dead()
    {

        Debug.Log(icon.count);
        if (icon != null)
        {
            icon.count -= 1;
        }
    }
}
