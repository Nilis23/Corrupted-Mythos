using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCrystals : MonoBehaviour
{
    [SerializeField]
    Sprite sprite;

    public void ChangeSprite()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
    }
}
