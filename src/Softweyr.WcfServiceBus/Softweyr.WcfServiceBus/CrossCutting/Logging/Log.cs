namespace Softweyr.CrossCutting.Logging
{
    using System;
    using System.Diagnostics;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Threading;

    using Softweyr.CrossCutting.Helpers;
    using Softweyr.CrossCutting.InversionOfControl;

    public static class Log
    {
        static Log()
        {
            try
            {
                logger = Ioc.Resolve<ILogger>();
            }
            catch (Exception)
            {
                logger = null;
            }
        }

        private static ILogger logger;

        [MethodImpl(MethodImplOptions.NoInlining)]
        [DebuggerStepThrough]
        public static void Trace()
        {
#if DEBUG
            if (logger != null)
            {
                logger.Trace(GetCallingMethod());
            }
#endif
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        [DebuggerStepThrough]
        public static void Debug(string message)
        {
#if DEBUG
            if (logger != null)
            {
                logger.Debug(GetCallingMethod().DeclaringType, message);
            }
#endif
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        [DebuggerStepThrough]
        public static void Debug(string Message, Exception Exception)
        {
            if (logger != null)
            {
                logger.Debug(GetCallingMethod().DeclaringType, Message, Exception);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        [DebuggerStepThrough]
        public static void Debug(Exception Exception)
        {
            if (logger != null)
            {
                logger.Debug
                (GetCallingMethod().DeclaringType, "Exception Occured: {0}".FormatWith(Exception.ToString()), Exception);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        [DebuggerStepThrough]
        public static void Information(string Message)
        {
            if (logger != null)
            {
                logger.Information(GetCallingMethod().DeclaringType, Message);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        [DebuggerStepThrough]
        public static void Information(string Message, Exception Exception)
        {
            if (logger != null)
            {
                logger.Information(GetCallingMethod().DeclaringType, Message, Exception);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        [DebuggerStepThrough]
        public static void Information(Exception Exception)
        {
            if (logger != null)
            {
                logger.Information
                (GetCallingMethod().DeclaringType, "Exception Occured: {0}".FormatWith(Exception.ToString()), Exception);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        [DebuggerStepThrough]
        public static void Warning(string Message)
        {
            if (logger != null)
            {
                logger.Warning(GetCallingMethod().DeclaringType, Message);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        [DebuggerStepThrough]
        public static void Warning(string Message, Exception Exception)
        {
            if (logger != null)
            {
                logger.Warning(GetCallingMethod().DeclaringType, Message, Exception);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        [DebuggerStepThrough]
        public static void Warning(Exception Exception)
        {
            if (logger != null)
            {
                logger.Warning
                (GetCallingMethod().DeclaringType, "Exception Occured: {0}".FormatWith(Exception.ToString()), Exception);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        [DebuggerStepThrough]
        public static void Error(string Message)
        {
            if (logger != null)
            {
                logger.Error(GetCallingMethod().DeclaringType, Message);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        [DebuggerStepThrough]
        public static void Error(string Message, Exception Exception)
        {
            if (logger != null)
            {
                logger.Error(GetCallingMethod().DeclaringType, Message, Exception);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        [DebuggerStepThrough]
        public static void Error(Exception Exception)
        {
            if (logger != null)
            {
                logger.Error
                (GetCallingMethod().DeclaringType, "Exception Occured: {0}".FormatWith(Exception.ToString()), Exception);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        [DebuggerStepThrough]
        public static void Fatal(string Message)
        {
            if (logger != null)
            {
                logger.Fatal(GetCallingMethod().DeclaringType, Message);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        [DebuggerStepThrough]
        public static void Fatal(string Message, Exception Exception)
        {
            if (logger != null)
            {
                logger.Fatal(GetCallingMethod().DeclaringType, Message, Exception);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        [DebuggerStepThrough]
        public static void Fatal(Exception Exception)
        {
            if (logger != null)
            {
                logger.Fatal
                (GetCallingMethod().DeclaringType, "Exception Occured: {0}".FormatWith(Exception.ToString()), Exception);
            }
        }

        private static MethodBase GetCallingMethod()
        {
            StackTrace trace = new StackTrace(Thread.CurrentThread, false);
            StackFrame frame = trace.GetFrame(2);
            MethodBase method = frame.GetMethod();
            return method;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void SetLevel(LoggingLevel level)
        {
            if (logger != null)
            {
                logger.SetLevel(level);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void SetApplicationName(string name)
        {
            if (logger != null)
            {
                logger.SetApplicationName(name);
            }
        }
    }
}