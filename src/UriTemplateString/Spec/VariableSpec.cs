using NullGuard;

namespace UriTemplateString.Spec
{
    /// <summary>
    /// Represents a variable specification as defined by URI Templates RFC
    /// </summary>
    public struct VariableSpec
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VariableSpec"/> struct.
        /// </summary>
        /// <param name="variable">The variable name.</param>
        /// <param name="modifier">The modifier.</param>
        internal VariableSpec(string variable, IModifier modifier)
            : this(variable)
        {
            this.Modifier = modifier;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VariableSpec"/> struct.
        /// </summary>
        /// <param name="name">The name.</param>
        internal VariableSpec(string name)
            : this()
        {
            this.Name = name;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the modifier.
        /// </summary>
        public IModifier Modifier { [return: AllowNull] get; }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        public override string ToString()
        {
            return $"{this.Name}{this.Modifier}";
        }
    }
}