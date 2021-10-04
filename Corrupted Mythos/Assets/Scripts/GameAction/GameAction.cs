using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameAction : MonoBehaviour
{
    public float delay;

    public abstract void Action();
}
