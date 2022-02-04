using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "Prefab Menu Controller", menuName = "Prefab Menu Controller", order = 0)]
public class PrefabMenu : ScriptableObject
{
    public string[] categories = new string[] {"Level Assets", "UI", "Enemies" };
    public string[] folder = new string[] { "Assets/PreFabs/Level Assets", "Assets/Prefabs/Actors" };
    public List<GameObject> Assets = new List<GameObject>();
    public int index;

    public void SpawnObj(GameObject obj)
    {
        Debug.Log(obj.ToString());
    }

    public void LoadAssets(int indx)
    {
        Debug.Log(indx);
        Assets.Clear();
        if(folder.Length < indx)
        {
            Debug.Log("Bad Index attempt - Index: " + indx + " Size: " + folder.Length);
            return;
        }
        else
        {
            Object[] data = AssetDatabase.LoadAllAssetsAtPath(folder[indx]);
            if(data == null || data.Length <= 0)
            {
                Debug.Log("Bad asset load");
                return;
            }
            else
            {
                foreach(Object obj in data)
                {
                    //Assets.Add(GameObject.GetPrefabAssetType(obj));
                    if(obj is GameObject)
                    {
                        Assets.Add(obj as GameObject);
                    }
                }
            }
        }
    }
}

[CustomEditor(typeof(PrefabMenu))]
public class PrefabMenu_CustGUI : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GUILayout.Space(15);

        PrefabMenu myMenu = (PrefabMenu)target;
        myMenu.index = EditorGUILayout.Popup(myMenu.index, myMenu.categories);
        //myMenu.LoadAssets(myMenu.index);

        //Display buttons

        GUILayout.Space(15);

        //Calc the width of each button
        float size = (Screen.width / 3) - 20;

        //Calc the total items to go through
        float items = myMenu.Assets.Count;
        int t = 0, z = 0;
        float rows = items / 3;
        for (float i = 0; i < rows; i++) //row control
        {
            GUILayout.BeginHorizontal();
            while(z < 3 && t < items) //Buttons in each row
            {
                GameObject obj = myMenu.Assets[t];
                if (obj != null) //Null protection
                {
                    if (GUILayout.Button(PrefabUtility.GetIconForGameObject(obj), GUILayout.Width(size), GUILayout.Height(size)))
                    {
                        myMenu.SpawnObj(obj);
                    }
                }
                t++;
                z++;
                GUILayout.Space(10);
            }
            GUILayout.EndHorizontal();
            GUILayout.Space(10);
            z = 0;
        }

    }

    
}
