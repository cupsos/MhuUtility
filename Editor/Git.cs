using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace MhuUtility
{
    public class Git : EditorWindow
    {
        [MenuItem("MhuUtility/Git/Status")]
        private static void gitStatus()
        {
            string command = @"C:\Program Files\Git\bin\git.exe";
            string workingDir = Directory.GetParent(Application.dataPath).FullName;
            string args = string.Join(" ", new string[] { "--work-tree=" + workingDir, "status" });
            var proc = new Process()
            {
                StartInfo = new ProcessStartInfo(command, args)
                {
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false
                }
            };
            proc.Start();
            EditorUtility.DisplayDialog("git status", proc.StandardOutput.ReadToEnd(), "close");
        }
    }
}