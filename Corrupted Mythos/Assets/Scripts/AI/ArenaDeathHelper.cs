using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaDeathHelper : MonoBehaviour
{
    CorruptedNode arena;
    public void SetArena(CorruptedNode node)
    {
        arena = node;
    }
    private void OnDestroy()
    {
        arena.removeEnemy(this.gameObject);
    }
}
