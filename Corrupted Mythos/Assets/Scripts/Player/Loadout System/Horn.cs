using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Horn", menuName = "Artifacts/Horn", order = 2)]
public class Horn : Artifact
{
    [SerializeField]
    float radius;

    public override void doAction(GameObject caller)
    {
        Collider2D[] hitCols = Physics2D.OverlapCircleAll(caller.transform.position, radius);
        List<Collider2D> hitEnemies = new List<Collider2D>();
        if (hitCols != null)
        {
            foreach (Collider2D col in hitCols)
            {
                if (col.gameObject.tag == "enemy" && !col.isTrigger)
                {
                    hitEnemies.Add(col);
                }
            }
            if (hitEnemies.Count != 0)
            {
                foreach (Collider2D col in hitEnemies)
                {

                    Debug.Log(col.gameObject.name + " hit");
                    col.gameObject.GetComponent<EnemyHealth>().minusHealth(5, 10);
                }
            }
        }
    }
}
