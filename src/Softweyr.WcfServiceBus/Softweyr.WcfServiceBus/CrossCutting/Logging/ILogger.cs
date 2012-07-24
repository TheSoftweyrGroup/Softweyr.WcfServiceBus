namespace Softweyr.CrossCutting.Logging
{
    using System;
    using System.Reflection;

    public interface ILogger
    {
        void Trace(MethodBase method);

        void Debug(Type callingType, string message);

        void Debug(Type callingType, string message, Exception exception);

        void Information(Type callingType, string message);

        void Information(Type callingType, string message, Exception exception);

        void Warning(Type callingType, string message);

        void Warning(Type callingType, string message, Exception exception);

        void Error(Type callingType, string message);

        void Error(Type callingType, string message, Exception exception);

        void Fatal(Type callingType, string message);

        void Fatal(Type callingType, string message, Exception exception);

        void SetLevel(LoggingLevel level);

        void SetApplicationName(string name);
    }
}