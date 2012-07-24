namespace Softweyr.CrossCutting.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;

    public static class Check
    {
        #region Nested type: Argument

        public static class Argument
        {
            [DebuggerStepThrough]
            public static void IsNotEmpty(Guid argument, string argumentName)
            {
                if (argument == Guid.Empty)
                {
                    throw new ArgumentException("\"{0}\" cannot be empty guid.".FormatWith(argumentName), argumentName);
                }
            }

            [DebuggerStepThrough]
            public static void IsNotEmpty(string argument, string argumentName)
            {
                if (string.IsNullOrEmpty((argument ?? string.Empty).Trim()))
                {
                    throw new ArgumentException("\"{0}\" cannot be blank.".FormatWith(argumentName), argumentName);
                }
            }

            [DebuggerStepThrough]
            public static void IsNotOutOfLength(string argument, int length, string argumentName)
            {
                if (argument.Trim().Length > length)
                {
                    throw new ArgumentException
                        ("\"{0}\" cannot be more than {1} character.".FormatWith(argumentName, length), argumentName);
                }
            }

            [DebuggerStepThrough]
            public static void IsNotNull(object argument, string argumentName)
            {
                if (argument == null)
                {
                    throw new ArgumentNullException(argumentName);
                }
            }

            [DebuggerStepThrough]
            public static void IsNotNegative(int argument, string argumentName)
            {
                if (argument < 0)
                {
                    throw new ArgumentOutOfRangeException(argumentName);
                }
            }

            [DebuggerStepThrough]
            public static void IsNotNegativeOrZero(int argument, string argumentName)
            {
                if (argument <= 0)
                {
                    throw new ArgumentOutOfRangeException(argumentName);
                }
            }

            [DebuggerStepThrough]
            public static void IsNotNegative(long argument, string argumentName)
            {
                if (argument < 0)
                {
                    throw new ArgumentOutOfRangeException(argumentName);
                }
            }

            [DebuggerStepThrough]
            public static void IsNotNegativeOrZero(long argument, string argumentName)
            {
                if (argument <= 0)
                {
                    throw new ArgumentOutOfRangeException(argumentName);
                }
            }

            [DebuggerStepThrough]
            public static void IsNotNegative(float argument, string argumentName)
            {
                if (argument < 0)
                {
                    throw new ArgumentOutOfRangeException(argumentName);
                }
            }

            [DebuggerStepThrough]
            public static void IsNotNegativeOrZero(float argument, string argumentName)
            {
                if (argument <= 0)
                {
                    throw new ArgumentOutOfRangeException(argumentName);
                }
            }

            [DebuggerStepThrough]
            public static void IsNotNegative(decimal argument, string argumentName)
            {
                if (argument < 0)
                {
                    throw new ArgumentOutOfRangeException(argumentName);
                }
            }

            [DebuggerStepThrough]
            public static void IsNotNegativeOrZero(decimal argument, string argumentName)
            {
                if (argument <= 0)
                {
                    throw new ArgumentOutOfRangeException(argumentName);
                }
            }

            [DebuggerStepThrough]
            public static void IsNotInPast(DateTime argument, string argumentName)
            {
                if (argument < Time.Now)
                {
                    throw new ArgumentOutOfRangeException(argumentName);
                }
            }

            [DebuggerStepThrough]
            public static void IsNotInFuture(DateTime argument, string argumentName)
            {
                if (argument > Time.Now)
                {
                    throw new ArgumentOutOfRangeException(argumentName);
                }
            }

            [DebuggerStepThrough]
            public static void IsNotNegative(TimeSpan argument, string argumentName)
            {
                if (argument < TimeSpan.Zero)
                {
                    throw new ArgumentOutOfRangeException(argumentName);
                }
            }

            [DebuggerStepThrough]
            public static void IsNotNegativeOrZero(TimeSpan argument, string argumentName)
            {
                if (argument <= TimeSpan.Zero)
                {
                    throw new ArgumentOutOfRangeException(argumentName);
                }
            }

            [DebuggerStepThrough]
            public static void IsNotEmpty<T>(ICollection<T> argument, string argumentName)
            {
                IsNotNull(argument, argumentName);

                if (argument.Count == 0)
                {
                    throw new ArgumentException("Collection cannot be empty.", argumentName);
                }
            }

            [DebuggerStepThrough]
            public static void IsNotOutOfRange(int argument, int min, int max, string argumentName)
            {
                if ((argument < min) ||
                    (argument > max))
                {
                    throw new ArgumentOutOfRangeException
                        (argumentName, "{0} must be between \"{1}\"-\"{2}\".".FormatWith(argumentName, min, max));
                }
            }

            [DebuggerStepThrough]
            public static void IsOfType(object argument, Type type, string argumentName)
            {
                IsNotNull(argument, argumentName);

                if (type.IsInterface)
                {
                    if (argument.GetType().GetInterface(type.FullName) == null)
                    {
                        throw new ArgumentException
                            ("\"{0}\" does not implement interface \"{1}\"".FormatWith(argumentName, type.Name));
                    }
                }
                else
                {
                    if (!(argument.GetType().IsSubclassOf(type) || argument.GetType() == type))
                    {
                        throw new ArgumentException
                            ("\"{0}\" is not of type \"{1}\"".FormatWith(argumentName, type.Name));
                    }
                }
            }

            [DebuggerStepThrough]
            public static void InheritsFrom(Type argument, Type parentType, string argumentName)
            {
                IsNotNull(argument, argumentName);

                if (
                    !(argument.IsSubclassOf(parentType) || argument == parentType ||
                      argument.GetInterface(parentType.FullName) != null))
                {
                    throw new ArgumentException
                        ("\"{0}\" does not inherit/implement \"{1}\"".FormatWith(argumentName, parentType.Name));
                }
            }

            [DebuggerStepThrough]
            public static void DoesNotContain<TType>
                (List<TType> collection, Predicate<TType> predicate, string argumentName)
            {
                IsNotNull(collection, argumentName);

                if (collection.Exists(predicate))
                {
                    throw new ArgumentException
                        ("{0} contains {1} that is not allowed.".FormatWith(argumentName, typeof (TType).Name));
                }
            }

            [DebuggerStepThrough]
            public static void IsNumeric(string intCode, string argumentName)
            {
                IsNotNull(intCode, argumentName);

                int startPos = intCode.StartsWith("-") ? 1 : 0;
                foreach (char cur in intCode.Substring(startPos))
                {
                    if (!char.IsDigit(cur))
                    {
                        throw new ArgumentException
                            ("{0} contains non-numeric character {1}.".FormatWith(argumentName, cur.ToString()));
                    }
                }
            }

            [DebuggerStepThrough]
            public static void IsValidFilePath(string filePath, string argumentName)
            {
                IsNotEmpty(filePath, argumentName);

                try
                {
                    Path.GetFullPath(filePath);
                }
                catch (Exception ex)
                {
                    throw new ArgumentException
                        (
                        "{0} does not contain a valid path '{1}'. Reason: {2}".FormatWith
                            (argumentName, filePath, ex.Message));
                }
            }

            [DebuggerStepThrough]
            public static void IsOneOf(string type, string argument, string argumentName, params string[] validValuesList)
            {
                bool found = false;
                int i = 0;
                while (!found && i < validValuesList.Length)
                    if (validValuesList[i++] == argument)
                        found = true;

                if (!found)
                {
                    throw new ArgumentException("{0} is not a possible value for {1} in {2}".FormatWith(argument, argumentName, type));
                }
            }
        }

        #endregion

        #region Nested type: Field

        public class Field
        {
            internal Field()
            {
            }

            [DebuggerStepThrough]
            public static void IsNotNull(object field, string fieldName)
            {
                if (field == null)
                {
                    throw new NullReferenceException
                        ("Field {0} must be given a value before this method can be called.".FormatWith(fieldName));
                }
            }

            [DebuggerStepThrough]
            public static void IsNull(object field, string fieldName)
            {
                if (field != null)
                {
                    throw new NullReferenceException
                        ("Field {0} has already been assigned a value.".FormatWith(fieldName));
                }
            }
        }

        #endregion
    }
}