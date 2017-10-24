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
        private const string GIT_DIR = @"C:\Program Files\Git\";
        private const string GIT_BASH = GIT_DIR + "git-bash.exe";
        private const string GIT_BIN = GIT_DIR + @"bin\git.exe";
        private static readonly string PROJECT_ROOT = Directory.GetParent(Application.dataPath).FullName;
        
        /*
        [MenuItem("MhuUtility/Git/Status")]
        private static void gitStatus()
        {
            const string args = "status";
            var proc = new Process()
            {
                StartInfo = new ProcessStartInfo(GIT_BIN, args)
                {
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    WorkingDirectory = PROJECT_ROOT
                }
            };
            proc.Start();
            EditorUtility.DisplayDialog("git status", proc.StandardOutput.ReadToEnd(), "close");
        }
        */

        [MenuItem("MhuUtility/Git/Explore")]
        private static void gitExplore()
        {
            new Process() { StartInfo = new ProcessStartInfo(GIT_BASH)
            { WorkingDirectory = PROJECT_ROOT} }.Start();
        }
    }
}