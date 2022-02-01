using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "Prefab Menu Controller", menuName = "Prefab Menu Controller", order = 0)]
public class PrefabMenu_ND : ScriptableObject
{
    //This one shows off the potential of linking the list with a scriptable object, but it is non-dynamic and cannot
    //change based on the file structure

    //Would need to find some way to link commands to existing prefabs, could not link up with an array of strings as it cannot be edited and also linked to commands

    [MenuItem("Prefabs/Item1")]
    public static void Item1()
    {
    }

    [MenuItem("Prefabs/Player/Item2")]
    public static void Item2()
    {
    }

    [MenuItem("Prefabs/Player/Item3")]
    public static void Item3()
    {
    }

    [MenuItem("Prefabs/Item4")]
    public static void Item4()
    {
    }
}
