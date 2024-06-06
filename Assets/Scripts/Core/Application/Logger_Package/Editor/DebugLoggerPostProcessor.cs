using UnityEngine;
using UnityEditor;
using System.IO;
using Core.Application.Logging;

public class DebugLoggerPostProcessor : AssetPostprocessor
{
    private static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
    {
        string settingsPath = "Assets/Resources/LogSettings.asset";

        if (!File.Exists(settingsPath))
        {
            LogSettings settings = ScriptableObject.CreateInstance<LogSettings>();
            AssetDatabase.CreateAsset(settings, settingsPath);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
    }
}