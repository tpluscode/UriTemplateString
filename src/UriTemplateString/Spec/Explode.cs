namespace UriTemplateString.Spec
{
    /// <summary>
    /// Represents the explode expression modifier
    /// </summary>
    /// <seealso cref="IModifier" />
    public struct Explode : IModifier
    {
        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return "*";
        }
    }
}