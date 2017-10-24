using UnityEngine;
using UnityEditor;
using System.IO;

namespace MhuUtility
{
    public class VisualStudio : EditorWindow
    {
        private static readonly string PROJECT_ROOT = Directory.GetParent(Application.dataPath).ToString();
        private static readonly string TEMP_BIN = Path.Combine(PROJECT_ROOT, "Temp", "UnityVS_bin");
        private static readonly string TEMP_OBJ = Path.Combine(PROJECT_ROOT, "Temp", "UnityVS_obj");

        [MenuItem("MhuUtility/VisualStudio/Clear")]
        private static void Clear()
        {
            if (Directory.Exists(TEMP_BIN))
                Directory.Delete(TEMP_BIN, true);

            if (Directory.Exists(TEMP_OBJ))
                Directory.Delete(TEMP_OBJ, true);
        }
    }
}
