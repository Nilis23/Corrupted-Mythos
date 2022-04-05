using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject RockPref;
    [SerializeField]
    float fallDist;

    float yHeight;
    GameObject rk = null;

    // Start is called before the first frame update
    void Start()
    {
        yHeight = GetComponent<BoxCollider2D>().size.y;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (rk == null)
        {
            GameObject obj = Instantiate(RockPref, new Vector3(transform.position.x, transform.position.y + yHeight, transform.position.z), Quaternion.Euler(0, 0, 0));
            obj.GetComponent<Rock>().SetFallDist(fallDist);
            rk = obj;
        }
    }
}
