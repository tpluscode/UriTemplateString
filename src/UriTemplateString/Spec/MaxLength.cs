namespace UriTemplateString.Spec
{
    /// <summary>
    /// Represents the max-length variable modifier
    /// </summary>
    /// <seealso cref="IModifier" />
    internal struct MaxLength : IModifier
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MaxLength"/> struct.
        /// </summary>
        /// <param name="maxLength">The maximum length.</param>
        public MaxLength(int maxLength)
        {
            this.Value = maxLength;
        }

        /// <summary>
        /// Gets the modifier value.
        /// </summary>
        public int Value { get; }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $":{this.Value}";
        }
    }
}