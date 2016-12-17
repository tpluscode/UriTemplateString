using System;

namespace UriTemplateString.Spec
{
    /// <summary>
    /// Represents a URI Template expression operator
    /// </summary>
    public struct Operator
    {
        /// <summary>
        /// Gets the query continuation operator.
        /// </summary>
        public static readonly Operator QueryContinuation = new Operator('&');

        /// <summary>
        /// Gets the path parameter operator.
        /// </summary>
        public static readonly Operator PathParameter = new Operator(';');

        /// <summary>
        /// Gets the path segment operator.
        /// </summary>
        public static readonly Operator PathSegment = new Operator('/');

        /// <summary>
        /// Gets the dot prefix operator
        /// </summary>
        public static readonly Operator DotPrefixedName = new Operator('.');

        /// <summary>
        /// Gets the hash fragment operator.
        /// </summary>
        public static readonly Operator HashFragment = new Operator('#');

        /// <summary>
        /// Gets the reserved character string operator.
        /// </summary>
        public static readonly Operator ReservedCharacterString = new Operator('+');

        /// <summary>
        /// Gets the query string operator.
        /// </summary>
        public static readonly Operator QueryComponent = new Operator('?');

        private readonly char value;

        private Operator(char value)
        {
            this.value = value;
        }

        /// <summary>
        /// Creates an oeprator from the string representation
        /// </summary>
        /// <param name="operatorCharacter">A string containing the operator character (excluding values reserved in RFC6570 for future use)</param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// When the parameter is not a single-character string containing one of valid operators
        /// </exception>
        public static Operator FromString(string operatorCharacter)
        {
            if (operatorCharacter.Length == 0)
            {
                return default(Operator);
            }

            switch (operatorCharacter)
            {
                case "?":
                    return Operator.QueryComponent;
                case "+":
                    return Operator.ReservedCharacterString;
                case "#":
                    return Operator.HashFragment;
                case ".":
                    return Operator.DotPrefixedName;
                case "/":
                    return Operator.PathSegment;
                case ";":
                    return Operator.PathParameter;
                case "&":
                    return Operator.QueryContinuation;
                default:
                    throw new ArgumentOutOfRangeException(nameof(operatorCharacter));
            }
        }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        public override string ToString()
        {
            if (this.value == default(char))
            {
                return string.Empty;
            }

            return this.value.ToString();
        }
    }
}