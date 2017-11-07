using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(SpriteGroup))]
public class SpriteGroupEditor : Editor
{
    private SpriteGroup myTarget;
    private void Awake() =>
        myTarget = target as SpriteGroup;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        float beforeAlpha = myTarget.Alpha;
        float afterAlpha = EditorGUILayout.Slider(nameof(myTarget.Alpha), beforeAlpha, 0, 1);
        if(beforeAlpha != afterAlpha)
        {
            myTarget.Alpha = afterAlpha;
            EditorSceneManager.MarkAllScenesDirty();
        }
    }
}
