using FluentAssertions;
using Xunit;

namespace UriTemplateString.Tests
{
    public class UriTemplateStringTests
    {
        [Fact]
        public void Is_castable_from_string()
        {
            // given
            const string strVal = "/some/simple/path";

            // when
            UriTemplateString template = strVal;

            // then
            template.ToString().Should().Be(strVal);
        }

        [Theory]
        [InlineData("/path/{var}")]
        [InlineData("/path{/optvar}")]
        [InlineData("/path{/optvar}{?query}")]
        [InlineData("/path/{p2,p3,p4}{.dots}{?query,q2,q3}")]
        [InlineData("/path{/optvar}{?expl*}")]
        [InlineData("/path{;params}?x={z}{&cont*}")]
        [InlineData("/path{/p:10,p2:5,p3,p4*}{?q}")]
        public void Constructed_retains_all_parts(string template)
        {
            // when
            var templateString = (UriTemplateString)template;

            // then
            templateString.ToString().Should().Be(template);
        }

        [Theory]
        [InlineData("/{path}", "/{path,var}")]
        [InlineData("/path/{p2}", "/path/{p2,var}")]
        [InlineData("/path/p2", "/path/p2,var")]
        public void Appending_variable_extends_last_variable_list(string template, string expected)
        {
        }
    }
}