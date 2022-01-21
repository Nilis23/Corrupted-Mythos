using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IoDAbomHealth : MonoBehaviour
{
    public OWAbomHealth health;
    public IconOfDestruction icon;
    public ParticleSystem death;

    private void Start()
    {
        health = this.GetComponent<OWAbomHealth>();
        death = this.transform.GetChild(2).GetComponentInChildren<ParticleSystem>();
    }

    public void dead()
    {
        Debug.Log(icon.count);
        if (icon != null)
        {
            icon.count -= 1;
            death.Play();
        }
    }
}
