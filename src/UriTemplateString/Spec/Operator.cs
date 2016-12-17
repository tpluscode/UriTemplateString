using System;

namespace UriTemplateString.Spec
{
    /// <summary>
    /// Represents a URI Template expression operator
    /// </summary>
    public struct Operator
    {
        private readonly char value;

        private Operator(char value)
        {
            this.value = value;
        }

        /// <summary>
        /// Gets the query continuation operator.
        /// </summary>
        public static Operator QueryContinuation { get; } = new Operator('&');

        /// <summary>
        /// Gets the path parameter operator.
        /// </summary>
        public static Operator PathParameter { get; } = new Operator(';');

        /// <summary>
        /// Gets the path segment operator.
        /// </summary>
        public static Operator PathSegment { get; } = new Operator('/');

        /// <summary>
        /// Gets the dot prefix operator
        /// </summary>
        public static Operator DotPrefixedName { get; } = new Operator('.');

        /// <summary>
        /// Gets the hash fragment operator.
        /// </summary>
        public static Operator HashFragment { get; } = new Operator('#');

        /// <summary>
        /// Gets the reserved character string operator.
        /// </summary>
        public static Operator ReservedCharacterString { get; } = new Operator('+');

        /// <summary>
        /// Gets the query string operator.
        /// </summary>
        public static Operator QueryComponent { get; } = new Operator('?');

        /// <summary>
        /// Creates an oeprator from the string representation
        /// </summary>
        /// <param name="operatorCharacter">A string containing the operator character (excluding values reserved in RFC6570 for future use)</param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// When the parameter is not a single-character string containing one of valid operators
        /// </exception>
        public static Operator FromString(string operatorCharacter)
        {
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
            return this.value.ToString();
        }
    }
}