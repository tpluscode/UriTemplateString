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

        [Fact]
        public void Concatenating_empty_string_with_template_Should_not_change_it()
        {
            // given
            var template = new UriTemplateString("{controller}{/action}");

            // when
            var concatenated = string.Empty + template;

            // then
            concatenated.Should().Be(template);
        }

        [Fact]
        public void Concatenating_template_empty_string_with_Should_not_change_it()
        {
            // given
            var template = new UriTemplateString("{controller}{/action}");

            // when
            var concatenated = template + string.Empty;

            // then
            concatenated.Should().Be(template);
        }
    }
}