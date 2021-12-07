using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverFunc : MonoBehaviour
{
    [SerializeField]
    GameObject door;
    [SerializeField]
    Animator anim;

    bool flipped = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Weapon" && !flipped && collision.gameObject.GetComponent<swing>().getStatus() == true)
        {
            doFunc();
            anim.SetTrigger("Lever");
            flipped = true;
        }
    }

    void doFunc()
    {
        door.GetComponent<BoxCollider2D>().enabled = false;
        door.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Open");
    }
}
