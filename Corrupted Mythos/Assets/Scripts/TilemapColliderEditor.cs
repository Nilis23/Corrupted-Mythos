using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TilemapCollider))]
public class TilemapColliderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GUILayout.Space(10);

        TilemapCollider myScript = (TilemapCollider)target;
        if(GUILayout.Button("Create Collider"))
        {
            myScript.BuildCollider();
        }
    }
}
