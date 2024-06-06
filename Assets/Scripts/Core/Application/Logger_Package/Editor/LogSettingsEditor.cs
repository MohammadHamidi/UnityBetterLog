using Core.Application.Logging;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LogSettings))]
public class LogSettingsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        LogSettings settings = (LogSettings)target;

        settings.logPrefix = EditorGUILayout.TextField("Log Prefix", settings.logPrefix);
        settings.timestampFormat = EditorGUILayout.TextField("Timestamp Format", settings.timestampFormat);
        settings.includeMethodName = EditorGUILayout.Toggle("Include Method Name", settings.includeMethodName);
        settings.includeLineNumber = EditorGUILayout.Toggle("Include Line Number", settings.includeLineNumber);
        settings.enableInfoLogs = EditorGUILayout.Toggle("Enable Info Logs", settings.enableInfoLogs);
        settings.enableWarningLogs = EditorGUILayout.Toggle("Enable Warning Logs", settings.enableWarningLogs);
        settings.enableErrorLogs = EditorGUILayout.Toggle("Enable Error Logs", settings.enableErrorLogs);

        // ... (existing code)

        if (GUI.changed)
        {
            EditorUtility.SetDirty(settings);
        }
    }
}