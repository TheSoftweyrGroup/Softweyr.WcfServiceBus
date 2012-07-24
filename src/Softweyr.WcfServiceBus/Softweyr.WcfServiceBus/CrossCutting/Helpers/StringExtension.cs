namespace Softweyr.CrossCutting.Helpers
{
    using System.Diagnostics;

    public static class StringExtension
    {
        [DebuggerStepThrough]
        public static string FormatWith(this string target, params object[] args)
        {
            Check.Argument.IsNotNull(target, "target");
            return string.Format(target, args);
        }
    }
}