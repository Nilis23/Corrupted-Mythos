using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyHealth : MonoBehaviour
{
    [SerializeField]
    int HP = 100;
    [SerializeField]
    Animator dummyanim;

    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = this.GetComponent<SpriteRenderer>();
    }

    public void doDamage(int damage)
    {
        HP -= damage;
        Debug.Log("Taking damage");
        sr.color = Color.red;
        Invoke("ResetColor", 1);

        if(HP <= 0)
        {
            Destroy(gameObject, 0.1f);
        }

        dummyanim.SetTrigger("Hit");
    }

    public void ResetColor()
    {
        sr.color = Color.white;
    }
}
