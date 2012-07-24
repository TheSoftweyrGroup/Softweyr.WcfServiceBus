namespace Softweyr.CrossCutting.Logging
{
    using System;

    /// <summary>
    /// The logging level to which log entries should be made.
    /// </summary>
    [Flags]
    public enum LoggingLevel
    {
        /// <summary>
        /// All Trace, Debug, Information, Warning, Error and Fatal log entries are recorded.
        /// </summary>
        Trace = 32,

        /// <summary>
        /// Only Debug, Information, Warning, Error and Fatal log entries are recorded.
        /// </summary>
        Debug = 16,

        /// <summary>
        /// Only Information, Warning, Error and Fatal log entries are recorded.
        /// </summary>
        Information = 8,

        /// <summary>
        /// Only Warning, Error and Fatal log entries are recorded.
        /// </summary>
        Warning = 4,

        /// <summary>
        /// Only Error and Fatal log entries are recorded.
        /// </summary>
        Error = 2,

        /// <summary>
        /// Only Fatal log entries are recorded.
        /// </summary>
        Fatal = 1,

        /// <summary>
        /// No log entries are recorded.
        /// </summary>
        None = 0,
    }
}