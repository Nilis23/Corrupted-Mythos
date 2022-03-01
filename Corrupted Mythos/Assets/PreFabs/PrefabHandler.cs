using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR

public class PrefabHandler : MonoBehaviour
{
    public ScriptableObject menu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SendRef()
    {
        Debug.Log("Sending");
        (menu as PrefabMenu).Selected = this;
    }
}

[CustomEditor(typeof(PrefabHandler))]
public class PrefabHandler_CustGUI : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        PrefabHandler myScript = (PrefabHandler)target;

        if (myScript.menu == null)
        {
            string[] results = AssetDatabase.FindAssets("Prefab Menu Controller");

            foreach (string s in results)
            {
                myScript.menu = (ScriptableObject)AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(s), typeof(ScriptableObject));

            }
        }

        myScript.SendRef();
    }

}

#endif
