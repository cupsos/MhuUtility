using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace MhuUtility
{
    public class Extract : EditorWindow
    {
        private static string GetPath(string fileName)
        {
            string objPath = AssetDatabase.GetAssetPath(Selection.activeObject);
            string parentPath = Directory.GetParent(objPath).ToString();
            UnityEngine.Debug.Log("obj = " + objPath + " par = " + parentPath);
            return Path.Combine(parentPath, "NewTexture");
        }
        const string extTex = "Assets/Extract/Texture";
        const string extMat = "Assets/Extract/Material";
        [MenuItem(extTex, true)]
        private static bool IsTexture() => Selection.activeObject is Texture;
        [MenuItem(extTex)]
        private static void ExtractTexture()
        {
            Texture target = Selection.activeObject as Texture;
            AssetDatabase.CreateAsset(Instantiate(target), GetPath("NewTex"));
        }
        [MenuItem(extMat, true)]
        private static bool IsMaterial() => Selection.activeObject is Material;
        [MenuItem(extMat)]
        private static void ExtractMaterial()
        {
            Material temp = new Material(Selection.activeObject as Material);
            AssetDatabase.CreateAsset(temp, GetPath("NewMat"));
        }
    }
}