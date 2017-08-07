using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MhuUtility
{
    public class AddFrontFileName : EditorWindow
    {
        List<string> filePaths = new List<string>();
        string header = string.Empty;

        [MenuItem("MhuUtility/AddFrontFileName")]
        private static void Init()
        {
            AddFrontFileName window = GetWindow<AddFrontFileName>();
            window.Show();
        }

        private void OnGUI()
        {
            if (GUILayout.Button("FolderDialog"))
            {
                string targetFolder = EditorUtility.OpenFolderPanel("Select Target Folder", "", "");
                if (targetFolder.Length == 0) return;
                filePaths = Directory.GetFiles(targetFolder).ToList();
            }
            EditorGUILayout.BeginHorizontal();
            header = EditorGUILayout.TextField(header);
            if (GUILayout.Button("ReName"))
            {
                for (int i = 0; i < filePaths.Count; i++)
                    FileUtil.MoveFileOrDirectory(filePaths[i], AddHeader(filePaths[i]));
            }
            EditorGUILayout.EndHorizontal();

            for (int i = 0; i < filePaths.Count; i++)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(AddHeader(filePaths[i]));
                if (GUILayout.Button("Dispose"))
                    filePaths.RemoveAt(i);
                EditorGUILayout.EndHorizontal();
            }

        }

        private string AddHeader(string original)
        {
            string oldFileName = Path.GetFileName(original);
            return original.Replace(oldFileName, header + oldFileName);
        }
    }
}