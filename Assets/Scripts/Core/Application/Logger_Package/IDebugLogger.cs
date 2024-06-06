using System.Runtime.CompilerServices;

namespace Core.Application.Logging
{
    public interface IDebugLogger
    {
        string GetClassName(string filePath);

        void LogInternal(string prefix, string message, LogLevel logLevel, TextColors color,
            [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "", [CallerLineNumber] int lineNumber = 0);

        void Log(string message, [CallerFilePath] string filePath = "",
            [CallerMemberName] string memberName = "", [CallerLineNumber] int lineNumber = 0);

        void LogWarning(string message, [CallerFilePath] string filePath = "",
            [CallerMemberName] string memberName = "", [CallerLineNumber] int lineNumber = 0);

        void LogError(string message, [CallerFilePath] string filePath = "",
            [CallerMemberName] string memberName = "", [CallerLineNumber] int lineNumber = 0);
    }
}