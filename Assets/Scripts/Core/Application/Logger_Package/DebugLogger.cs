using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Core.Application.Logging
{
    public class DebugLogger : IDebugLogger
    {
        private Dictionary<string, string> fileNameCache = new Dictionary<string, string>();

        public string GetClassName(string filePath)
        {
            if (!fileNameCache.TryGetValue(filePath, out var className))
            {
                className = System.IO.Path.GetFileNameWithoutExtension(filePath);
                fileNameCache[filePath] = className;
            }

            return className;
        }

        public void LogInternal(string prefix, string message, LogLevel logLevel, TextColors color,
            [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "", [CallerLineNumber] int lineNumber = 0)
        {
            var settings = LogSettings.Instance;

            if (settings == null)
            {
                Debug.LogError("LogSettings asset is missing or invalid.");
                return;
            }

            if (settings.currentLogLevel >= logLevel)
            {
                var className = GetClassName(filePath);
                var timestamp = System.DateTime.Now.ToString(settings.timestampFormat);
                var methodInfo = settings.includeMethodName ? $"[{memberName}]" : "";
                var lineInfo = settings.includeLineNumber ? $"(Line {lineNumber})" : "";
                var logMessage =
                    $"{settings.logPrefix} {timestamp} <color={color}>[{className}] {methodInfo} {lineInfo} {prefix}: {message}</color>";

                switch (logLevel)
                {
                    case LogLevel.Error:
                        if (settings.enableErrorLogs)
                            UnityEngine.Debug.LogError(logMessage);
                        break;
                    case LogLevel.Warning:
                        if (settings.enableWarningLogs)
                            UnityEngine.Debug.LogWarning(logMessage);
                        break;
                    default:
                        if (settings.enableInfoLogs)
                            UnityEngine.Debug.Log(logMessage);
                        break;
                }
            }
        }

        public void Log(string message, [CallerFilePath] string filePath = "",
            [CallerMemberName] string memberName = "", [CallerLineNumber] int lineNumber = 0)
        {
#if UNITY_EDITOR || DEBUG
            var settings = LogSettings.Instance;
            LogInternal("Info", message, LogLevel.Info, settings.infoColor, filePath, memberName, lineNumber);
#endif
        }

        public void LogWarning(string message, [CallerFilePath] string filePath = "",
            [CallerMemberName] string memberName = "", [CallerLineNumber] int lineNumber = 0)
        {
#if UNITY_EDITOR || DEBUG
            var settings = LogSettings.Instance;
            LogInternal("Warning", message, LogLevel.Warning, settings.warningColor, filePath, memberName, lineNumber);
#endif
        }

        public void LogError(string message, [CallerFilePath] string filePath = "",
            [CallerMemberName] string memberName = "", [CallerLineNumber] int lineNumber = 0)
        {
#if UNITY_EDITOR || DEBUG
            var settings = LogSettings.Instance;
            LogInternal("Error", message, LogLevel.Error, settings.errorColor, filePath, memberName, lineNumber);
#endif
        }
    }
}