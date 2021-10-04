using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameActionTrigger : MonoBehaviour
{
    public List<GameAction> gameActions;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(nameof(GameActionSequence));
    }
    IEnumerator GameActionSequence()
    {
        for(int i = 0; i < gameActions.Count; i++)
        {
            yield return new WaitForSeconds(gameActions[i].delay);
            gameActions[i].Action();
        }
    }
}
