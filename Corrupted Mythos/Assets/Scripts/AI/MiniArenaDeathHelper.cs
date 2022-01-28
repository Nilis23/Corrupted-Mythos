using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniArenaDeathHelper : MonoBehaviour
{
    MiniNode arena;
    public void SetArena(MiniNode node)
    {
        arena = node;
        Debug.Log(arena.name);
    }
    private void OnDestroy()
    {

        arena.removeEnemy(this.gameObject);
    }
}
