using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UriTemplateString.Spec;

namespace UriTemplateString
{
    /// <summary>
    /// Factory which creates URI Template parts (literals and expressions)
    /// </summary>
    internal class UriTemplatePartFactory
    {
        /// <summary>
        /// Gets the template parts from RegEx captures.
        /// </summary>
        public IEnumerable<ITemplatePart> GetParts(CaptureCollection capturedParts)
        {
            return from Capture capture in capturedParts
                   select this.CreatePart(capture.Value);
        }

        /// <summary>
        /// Creates a part.
        /// </summary>
        internal ITemplatePart CreatePart(string templatePart)
        {
            if (templatePart.StartsWith("{"))
            {
                var expressionMatch = TemplateSyntax.ExpressionRegex.Match(templatePart);
                var @operator = expressionMatch.Groups["op"].ToString();

                var variables = from Match varspec in TemplateSyntax.VariableSpecRegex.Matches(templatePart)
                                select this.CreateVariable(varspec);

                return new ExpressionPart(@operator, variables);
            }
            else
            {
                return new LiteralPart(templatePart);
            }
        }

        private VariableSpec CreateVariable(Match varspec)
        {
            var name = varspec.Groups["varname"].ToString();

            if (varspec.Groups["mod"].Success)
            {
                IModifier modifier = this.CreateModifier(varspec);
                return new VariableSpec(name, modifier);
            }

            return new VariableSpec(name);
        }

        private IModifier CreateModifier(Match varspec)
        {
            if (varspec.Groups["max"].Success)
            {
                return new MaxLength(Convert.ToInt32(varspec.Groups["max"].ToString()));
            }

            return default(Explode);
        }
    }
}