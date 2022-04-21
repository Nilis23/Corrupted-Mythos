using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

[CustomEditor(typeof(StateManager))]
public class ManagerInspector : Editor
{
    public VisualTreeAsset m_InspectorXML;
    public override VisualElement CreateInspectorGUI()
    {
        VisualElement myInspector = new VisualElement();

        VisualTreeAsset visualtree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/statemanager_rough");
        m_InspectorXML.CloneTree(myInspector);

        //VisualElement inspectorFoldout = myInspector.Q("Default_Inspector");
        //InspectorElement.FillDefaultInspector(inspectorFoldout, serializedObject, this);

        return myInspector;
    }
}
