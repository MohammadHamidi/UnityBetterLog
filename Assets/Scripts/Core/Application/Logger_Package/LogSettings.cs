using UnityEngine;

namespace Core.Application.Logging
{
    [CreateAssetMenu(fileName = "LogSettings", menuName = "Logging/Log Settings", order = 1)]
    public class LogSettings : ScriptableObject
    {
        public string logPrefix = "[DebugLogger]";
        public string timestampFormat = "HH:mm:ss.fff";
        public bool includeMethodName = true;
        public bool includeLineNumber = false;
        public bool enableInfoLogs = true;
        public bool enableWarningLogs = true;
        public bool enableErrorLogs = true;

        public TextColors infoColor = TextColors.White;
        public TextColors warningColor = TextColors.Yellow;
        public TextColors errorColor = TextColors.Red;
        public LogLevel currentLogLevel = LogLevel.Info;

        // Singleton pattern for easy access
        private static LogSettings _instance;

        public static LogSettings Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = Resources.Load<LogSettings>("LogSettings");
                    if (_instance == null)
                    {
                        Debug.LogError("LogSettings asset not found in Resources folder. Using default settings.");
                        _instance = CreateInstance<LogSettings>();
                    }
                }
                return _instance;
            }
        }
    }
}