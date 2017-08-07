using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEditor;

namespace MhuUtility
{
    public class Adb : EditorWindow
    {
        [MenuItem("MhuUtility/Adb/install")]
        private static void AdbInstall()
        {
            string apkPath;
            try
            {
                apkPath = Directory.GetParent(Application.dataPath)
                    .GetFiles().Where(file => file.Extension == ".apk")
                    .First().FullName;
            }
            catch
            {
                UnityEngine.Debug.LogError("APK doesn't exist");
                return;
            }
            if (EditorUtility.DisplayDialog("adb install", apkPath, "설치", "취소"))
            {
                var InstallProc = new Process()
                {
                    StartInfo = new ProcessStartInfo()
                    {
                        FileName = "adb",
                        Arguments = "install -r " + apkPath
                    }
                };
                InstallProc.Start();
                InstallProc.WaitForExit();
                new Process()
                {
                    StartInfo = new ProcessStartInfo()
                    {
                        FileName = "adb",
                        Arguments = "shell monkey -p com.MhuGames.miniPuzzleFriends -c android.intent.category.LAUNCHER 1"
                    }
                }.Start();
            }
        }
        [MenuItem("MhuUtility/Adb/logcat")]
        private static void AdbLogcat()
        {
            new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = "adb",
                    Arguments = "logcat Unity:* *:S"
                }
            }.Start();
        }
    }
}