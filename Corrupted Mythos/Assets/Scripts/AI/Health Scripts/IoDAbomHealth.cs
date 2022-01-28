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
        int x = gameObject.transform.childCount;
        death = this.transform.GetChild(x - 1).GetComponentInChildren<ParticleSystem>();
    }

    public void dead()
    {
        if (icon != null)
        {
            icon.count -= 1;
            death.Play();
        }
    }
}
