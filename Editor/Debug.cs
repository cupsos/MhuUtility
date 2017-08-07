using Microsoft.Win32;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace MhuUtility
{
    public class Debug : EditorWindow
    {
        [MenuItem("MhuUtility/Debug/OpenRegedit")]
        private static void OpenRegistry()
        {
            Microsoft.Win32.Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Applets\Regedit", "LastKey",
                @"HKEY_CURRENT_USER\Software\Unity\UnityEditor\" + Application.companyName + @"\" + Application.productName);
            new Process()
            {
                StartInfo = new ProcessStartInfo("regedit")
            }.Start();
        }
    }
}