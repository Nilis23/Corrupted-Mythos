using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PrefabMenu : EditorWindow
{
    public string[] options = new string[] { "Cube", "Sphere", "Plane", "Hello", "There", "General", "Kenobi", "Plaayer"  };
    public int index = 0;

    [MenuItem("Window/Prefab Menu %#&p")] //The container for the window
    static void Init()
    {
        EditorWindow window = GetWindow(typeof(PrefabMenu));
        window.Show();
    }

    private void OnInspectorUpdate()
    {
        Repaint(); //Reloading does not occur for some reason, window updates when its manually reloaded
        Debug.Log("Repainted");
    }

    void OnGUI()
    {
        index = EditorGUILayout.Popup(index, options); //The actual menu 

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
