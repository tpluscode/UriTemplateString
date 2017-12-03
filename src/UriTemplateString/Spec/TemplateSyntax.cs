using System.Text.RegularExpressions;

namespace UriTemplateString.Spec
{
    /// <summary>
    /// Regular expressions which represent the URI Template syntax
    /// </summary>
    internal static class TemplateSyntax
    {
        /// <summary>
        /// The operator regex
        /// </summary>
        internal static readonly Regex OperatorRegex = new Regex(@"[+#\.\/;?&=,!@|]?");

        /// <summary>
        /// The variable spec regex
        /// </summary>
        internal static readonly Regex VariableSpecRegex = new Regex(@"(?<varname>[a-z\d_][\.a-z\d_]*)(?<mod>(?<explode>\*)|(?>:(?<max>\d+)))?", RegexOptions.IgnoreCase);

        /// <summary>
        /// The literal regex
        /// </summary>
        internal static readonly Regex LiteralRegex = new Regex(@"[^{{}}<>\\`|]+");

        /// <summary>
        /// The expression regex
        /// </summary>
        internal static readonly Regex ExpressionRegex = new Regex($"{{(?<op>{OperatorRegex})(?>(?<varspec>{VariableSpecRegex}),?)+}}", RegexOptions.IgnoreCase);

        /// <summary>
        /// The complete template regex
        /// </summary>
        internal static readonly Regex TemplateRegex = new Regex($"^(?<part>{LiteralRegex}|{ExpressionRegex})+$", RegexOptions.IgnoreCase);
    }
}