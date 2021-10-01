using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingStone : MonoBehaviour
{
    [SerializeField]
    ParticleSystem effect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !effect.isPlaying)
        {
            effect.Play();
        }
    }
}
