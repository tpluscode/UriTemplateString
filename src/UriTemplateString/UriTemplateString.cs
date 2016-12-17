using System;
using System.Collections.Generic;
using System.Linq;
using UriTemplateString.Spec;

namespace UriTemplateString
{
    /// <summary>
    /// Represents an URI Template parsed according to the RFC specification
    /// </summary>
    public class UriTemplateString
    {
        private static readonly UriTemplatePartFactory URITemplatePartFactory = new UriTemplatePartFactory();

        /// <summary>
        /// Initializes a new instance of the <see cref="UriTemplateString"/> class.
        /// </summary>
        /// <param name="value">The template string.</param>
        public UriTemplateString(string value)
            : this(GetTemplateParts(value))
        {
        }

        private UriTemplateString(IEnumerable<ITemplatePart> templateParts)
        {
            this.Parts = templateParts.ToList();
        }

        /// <summary>
        /// Gets the parts (literal or expressions).
        /// </summary>
        public IReadOnlyList<ITemplatePart> Parts { get; }

        /// <summary>
        /// Performs an implicit conversion from <see cref="string"/> to <see cref="UriTemplateString"/>.
        /// </summary>
        /// <param name="uriTemplate">The URI Template.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator UriTemplateString(string uriTemplate)
        {
            return new UriTemplateString(uriTemplate);
        }

        /// <summary>
        /// Concatenates two templates
        /// </summary>
        public static UriTemplateString operator +(UriTemplateString path, UriTemplateString template)
        {
            return new UriTemplateString(path.Parts.Concat(template.Parts));
        }

        /// <summary>
        /// Returns the URI Template string as concatentation of its <see cref="Parts"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return string.Join(string.Empty, this.Parts);
        }

        /// <summary>
        /// Appends a query parameter variable to query string.
        /// </summary>
        /// <param name="name">The variable name.</param>
        /// <param name="explode">if set to <c>true</c> adds an exploded variable.</param>
        /// <returns>A new instance of <see cref="UriTemplateString"/> with appended query string parameter</returns>
        public UriTemplateString AppendQueryParam(string name, bool explode = false)
        {
            IEnumerable<ITemplatePart> newParts;
            var queryVariable = explode ? new VariableSpec(name, default(Explode)) : new VariableSpec(name);

            var lastExpression = this.Parts.Last() as Expression?;
            if (Operator.QueryComponent.Equals(lastExpression?.Operator) || Operator.QueryContinuation.Equals(lastExpression?.Operator))
            {
                ITemplatePart newQuery = new Expression(lastExpression.Value.Operator, lastExpression?.VariableList.Concat(new[] { queryVariable }));

                newParts = this.Parts
                    .Take(this.Parts.Count - 1)
                    .Concat(new[] { newQuery });
            }
            else if (this.Parts.OfType<Literal>().Any(p => p.ToString().Contains("?")))
            {
                ITemplatePart queryContinuation = new Expression(Operator.QueryContinuation, new[] { queryVariable });
                newParts = this.Parts.Concat(new[] { queryContinuation });

                return new UriTemplateString(newParts);
            }
            else
            {
                var queryExpression = new Expression(Operator.QueryComponent, new[] { queryVariable });

                newParts = this.Parts.Concat(new ITemplatePart[]
                {
                    queryExpression
                });
            }

            return new UriTemplateString(newParts);
        }

        private static IEnumerable<ITemplatePart> GetTemplateParts(string value)
        {
            var match = TemplateSyntax.TemplateRegex.Match(value);
            if (match.Success)
            {
                return URITemplatePartFactory.GetParts(match.Groups["part"].Captures);
            }

            throw new ArgumentException("Value is not a valid URI Template");
        }
    }
}