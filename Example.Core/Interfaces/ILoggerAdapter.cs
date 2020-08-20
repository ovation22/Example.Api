using System;

namespace Example.Core.Interfaces
{
    public interface ILoggerAdapter<T>
    {
        void LogInformation(string message, params object[] args);
        void LogWarning(string message, params object[] args);
        void LogWarning(Exception ex, string message, params object[] args);
        void LogError(Exception ex, string message, params object[] args);
    }
}
