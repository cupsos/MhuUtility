using UnityEngine;
using UnityEditor;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace MhuUtility
{
    public class VisualStudio : EditorWindow
    {
        private static readonly string PROJECT_ROOT = Directory.GetParent(Application.dataPath).FullName;
        private static readonly string TEMP_BIN = Path.Combine(PROJECT_ROOT, "Temp", "UnityVS_bin");
        private static readonly string TEMP_OBJ = Path.Combine(PROJECT_ROOT, "Temp", "UnityVS_obj");
        private static readonly string VS_CONFIG = Path.Combine(PROJECT_ROOT, ".vs");
        private static readonly string[] TEMP_DIRS = { TEMP_BIN, TEMP_OBJ, VS_CONFIG };
        private static readonly Regex SOLUTION_FILE = new Regex(@"\.(csproj|sln)$");

        [MenuItem("MhuUtility/VisualStudio/Clear")]
        private static void Clear()
        {
            foreach (string path in TEMP_DIRS)
                if (Directory.Exists(path))
                    Directory.Delete(path, true);
            
            foreach (string solutionFile in (from file in Directory.GetFiles(PROJECT_ROOT)
                                             where SOLUTION_FILE.IsMatch(file)
                                             select file))
                File.Delete(solutionFile);
        }
    }
}
