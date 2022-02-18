using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class wispLoc : MonoBehaviour
{
    public float AddedBerserk;
    public static Action<float> BerserkIncrement = delegate { };

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Souls")
        {
            AddedBerserk = collision.GetComponent<wispParticles>().StoredBerserk;
            Destroy(collision);
            BerserkIncrement(AddedBerserk);
        }
    }
}
