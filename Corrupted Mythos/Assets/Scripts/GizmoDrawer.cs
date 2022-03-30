using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoDrawer : MonoBehaviour
{
    [SerializeField]
    bool box;
    [SerializeField]
    bool circle;

    [Space]
    [SerializeField]
    float lr;
    [SerializeField]
    float h;

    [Space]
    [SerializeField]
    Color gcolor;

    private void OnDrawGizmosSelected()
    {
        if (box)
        {
            Gizmos.color = gcolor;
            Gizmos.DrawCube(transform.position, new Vector3(lr, h, 1));
        }
        else if (circle)
        {
            Gizmos.color = gcolor;
            Gizmos.DrawSphere(transform.position, lr);
        }
    }
}
