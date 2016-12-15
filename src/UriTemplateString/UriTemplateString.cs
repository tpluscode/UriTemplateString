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

        private UriTemplateString(string value)
        {
            var match = TemplateSyntax.TemplateRegex.Match(value);
            if (match.Success)
            {
                this.Parts = URITemplatePartFactory.GetParts(match.Groups["part"].Captures).ToList();
            }
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
        /// Returns the URI Template string as concatentation of its <see cref="Parts"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return string.Join(string.Empty, this.Parts);
        }
    }
}