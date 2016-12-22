using System;
using Xunit;

namespace UriTemplateString.Tests
{
    public class InvalidUriTemplateFixture
    {
        [Fact]
        public void Should_throw_when_created_from_empty_string()
        {
            Assert.Throws<ArgumentException>(() => new UriTemplateString(string.Empty));
        }

        [Fact]
        public void Should_throw_when_created_from_template_with_unclosed_expression()
        {
            Assert.Throws<ArgumentException>(() => new UriTemplateString("{/unclosed"));
        }

        [Fact]
        public void Should_throw_when_created_from_template_with_unsupported_expression_operator()
        {
            Assert.Throws<ArgumentException>(() => new UriTemplateString("{'unclosed}"));
        }
    }
}