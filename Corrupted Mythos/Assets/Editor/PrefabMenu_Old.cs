using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class PrefabMenu_Old : EditorWindow
{
    public string[] options = new string[] { "Cube", "Sphere", "Plane", "Hello", "There", "General", "Kenobi", "Plaayer"  };
    public int index = 0;
    public int index2 = 0;

    [MenuItem("Window/Prefab Menu %#&p")] //The container for the window
    static void Init()
    {
        EditorWindow window = GetWindow(typeof(PrefabMenu_Old));
        window.Show();
    }

    private void OnInspectorUpdate()
    {
        if(index == 2)
        {
            //EditorGUILayout.Popup(index, options);
        }
        Repaint();
    }

    void OnGUI()
    {
        index = EditorGUILayout.Popup(index, options); //The actual menu 

        GUILayout.Space(15f);
        index2 = EditorGUILayout.Popup(index2, options);
        GUILayout.Space(15f);


        if (GUILayout.Button("Instantiate")) //Button to create prefab
        {
            InstantiatePrefab();
        }
    }

    void InstantiatePrefab()
    {
        //The function to create a prefab
    }
}
