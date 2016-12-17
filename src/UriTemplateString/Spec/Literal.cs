namespace UriTemplateString.Spec
{
    /// <summary>
    /// Represents a literal part of an URI Template
    /// </summary>
    /// <seealso cref="ITemplatePart" />
    public struct Literal : ITemplatePart
    {
        private readonly string literal;

        /// <summary>
        /// Initializes a new instance of the <see cref="Literal"/> struct.
        /// </summary>
        /// <param name="literal">The literal value.</param>
        internal Literal(string literal)
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