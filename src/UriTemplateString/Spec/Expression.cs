using System.Collections.Generic;
using System.Linq;

namespace UriTemplateString.Spec
{
    /// <summary>
    /// Represents an expression part of an URI Template
    /// </summary>
    /// <seealso cref="ITemplatePart" />
    public struct Expression : ITemplatePart
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Expression"/> struct.
        /// </summary>
        /// <param name="operator">The operator.</param>
        /// <param name="variableList">The variable list.</param>
        internal Expression(string @operator, IEnumerable<VariableSpec> variableList)
        {
            this.Operator = @operator;
            this.VariableList = variableList.ToList();
        }

        /// <summary>
        /// Gets the operator.
        /// </summary>
        public string Operator { get; }

        /// <summary>
        /// Gets the variable list.
        /// </summary>
        public IReadOnlyList<VariableSpec> VariableList { get; }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        public override string ToString()
        {
            return $"{{{this.Operator}{string.Join(",", this.VariableList)}}}";
        }
    }
}