namespace UriTemplateString.Spec
{
    /// <summary>
    /// Represents a literl part of an URI Template
    /// </summary>
    /// <seealso cref="ITemplatePart" />
    public struct LiteralPart : ITemplatePart
    {
        private readonly string literal;

        /// <summary>
        /// Initializes a new instance of the <see cref="LiteralPart"/> struct.
        /// </summary>
        /// <param name="literal">The literal value.</param>
        internal LiteralPart(string literal)
        {
            this.literal = literal;
        }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        public override string ToString()
        {
            return this.literal;
        }
    }
}