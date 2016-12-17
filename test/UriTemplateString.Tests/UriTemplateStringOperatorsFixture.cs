using FluentAssertions;
using Xunit;

namespace UriTemplateString.Tests
{
    public class UriTemplateStringOperatorsFixture
    {
        [Fact]
        public void Should_concatenate_two_templates()
        {
            // given
            var left = new UriTemplateString("http://example.com/{area}/");
            var right = new UriTemplateString("{controller}{/action}");

            // when
            var concat = left + right;

            // then
            concat.ToString().Should().Be("http://example.com/{area}/{controller}{/action}");
        }

        [Fact]
        public void Should_concatenate_template_with_string()
        {
            // given
            var left = new UriTemplateString("http://example.com/{area}/");
            var right = "{controller}{/action}";

            // when
            var concat = left + right;

            // then
            concat.ToString().Should().Be("http://example.com/{area}/{controller}{/action}");
        }

        [Fact]
        public void Should_concatenate_string_with_template()
        {
            // given
            var left = "http://example.com/{area}/";
            var right = new UriTemplateString("{controller}{/action}");

            // when
            var concat = left + right;

            // then
            concat.ToString().Should().Be("http://example.com/{area}/{controller}{/action}");
        }
    }
}