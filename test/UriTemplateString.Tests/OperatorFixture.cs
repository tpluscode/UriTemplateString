using System;
using UriTemplateString.Spec;
using Xunit;

namespace UriTemplateString.Tests
{
    public class OperatorFixture
    {
        [Fact]
        public void Should_throw_when_constructed_with_unsupported_operator_character()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Operator.FromString("_"));
        }

        [Theory]
        [InlineData("=")]
        [InlineData(",")]
        [InlineData("!")]
        [InlineData("@")]
        [InlineData("|")]
        public void Should_throw_when_constructed_with_operator_reserved_for_future_use(string op)
        {
            Assert.Throws<NotImplementedException>(() => Operator.FromString(op));
        }
    }
}