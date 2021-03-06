using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "Prefab Menu Controller", menuName = "Prefab Menu Controller", order = 0)]
public class PrefabMenu : ScriptableObject
{
#if UNITY_EDITOR

    //Public facing variables
    public string[] categories = new string[] {"Level Assets", "UI", "Enemies" };
    public string[] folder = new string[] { "Assets/PreFabs/Level Assets/", "Assets/Prefabs/Actors/" };
    [HideInInspector]
    public List<GameObject> Assets = new List<GameObject>();
    [HideInInspector]
    public int index;
    [HideInInspector]
    public PrefabHandler Selected;
    [HideInInspector]
    public bool replace;

    //Private variables
    private string[] list;

    public void SpawnObj(GameObject obj)
    {
        Debug.Log(obj.ToString());
        GameObject clone = (GameObject)PrefabUtility.InstantiatePrefab(obj);

        if(replace && Selected != null)
        {
            clone.transform.position = Selected.transform.position;
            DestroyImmediate(Selected.gameObject);
            Selected = clone.GetComponent<PrefabHandler>();
        }
        else
        {
            Camera sceneCam = SceneView.lastActiveSceneView.camera;
            Vector3 placePos = sceneCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
            clone.transform.position = new Vector3(placePos.x, placePos.y, 1);
        }

        Selection.activeObject = clone;

        
    }

    public void LoadAssets(int indx)
    {
        if (indx < folder.Length)
        {
            Assets.Clear();
            if (folder.Length < indx)
            {
                Debug.Log("Bad Index attempt - Index: " + indx + " Size: " + folder.Length);
                return;
            }
            else
            {
                list = AssetDatabase.FindAssets("t:prefab", new[] { folder[indx] });

                if (list == null || list.Length <= 0)
                {
                    Debug.Log("Bad asset load");
                    return;
                }
                else
                {
                    for (int x = 0; x < list.Length; x++)
                    {
                        Assets.Add((GameObject)AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(list[x]), typeof(GameObject)));
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

        myMenu.replace = GUILayout.Toggle(myMenu.replace, "Replace");

        GUILayout.Space(15);

        myMenu.index = EditorGUILayout.Popup(myMenu.index, myMenu.categories);
        
        //Load all of the assets in the selected directory
        myMenu.LoadAssets(myMenu.index);

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
                    if (GUILayout.Button(AssetPreview.GetAssetPreview(obj), GUILayout.Width(size), GUILayout.Height(size)))
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

#endif

}

