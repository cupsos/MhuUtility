using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TransformGroup))]
public class TransformGroupEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        TransformGroup myTarget = target as TransformGroup;
        Vector3 curAvgPos = myTarget.AveragePosition;
        Vector3 inputAvgPos = EditorGUILayout.Vector3Field("AvgPos", curAvgPos);
        if (curAvgPos != inputAvgPos)
            myTarget.AveragePosition = inputAvgPos;
        if (GUILayout.Button("avg <- (0,0,0)"))
            myTarget.AveragePosition = Vector3.zero;
    }
}