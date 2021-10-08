using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
[ExecuteInEditMode]
[RequireComponent(typeof(EdgeCollider2D))]
public class TraceTileMap : MonoBehaviour
{
    private EdgeCollider2D edgeCollider;    
    public float length;     
    public LayerMask mask;    
    private RaycastHit2D hit;
    public List<Vector2> tracePoints = new List<Vector2>();
    private Vector2 cachedPoint;

    private void OnEnable()
    {
        edgeCollider = GetComponent<EdgeCollider2D>();
    }
    public void Trace()
    {
        tracePoints.Clear();

        for (float x = 0; x < length; x++)
        {
            hit = Physics2D.Raycast(new Vector2(transform.position.x + x, transform.position.y),
                                 -Vector2.up, 100, mask);
            //tracePoints.Add(new Vector2(hit.point.x - transform.position.x,hit.point.y-transform.position.y));
           
            if (hit.collider != null)
            {
                if (x == 0)
                {
                    tracePoints.Add(new Vector2(hit.point.x - transform.position.x, hit.point.y - transform.position.y));
                    cachedPoint = tracePoints[0];
                }
                else
                {
                    if ((hit.point.y - transform.position.y) != cachedPoint.y)
                    {
                        if (hit.point.y - transform.position.y > cachedPoint.y)
                        {
                            //stores the last point position which is minus of the current
                            cachedPoint = new Vector2(hit.point.x - transform.position.x, cachedPoint.y);
                            tracePoints.Add(cachedPoint);

                            //store the new lower y point
                            cachedPoint = new Vector2(hit.point.x - transform.position.x, hit.point.y - transform.position.y);
                            tracePoints.Add(cachedPoint);
                        }
                        else
                        {
                            //stores the last point position which is minus of the current
                            cachedPoint = new Vector2(hit.point.x - transform.position.x - 1, cachedPoint.y);
                            tracePoints.Add(cachedPoint);

                            //store the new lower y point
                            cachedPoint = new Vector2(hit.point.x - transform.position.x - 1, hit.point.y - transform.position.y);
                            tracePoints.Add(cachedPoint);
                        }
                    }
                }
            } 
        }
        edgeCollider.SetPoints(tracePoints);
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(TraceTileMap))]
public class TraceTileMapCI : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        TraceTileMap tMap = (TraceTileMap)target;

        if(GUILayout.Button("Trace TileMap"))
        {
            tMap.Trace();
        }
    }   
}
#endif
