using FluentAssertions;
using Xunit;

namespace UriTemplateString.Tests
{
    public class UriTemplateStringArithmeticsFixture
    {
        [Fact]
        public void Can_append_exploded_query_param_to_literal_template()
        {
            // given
            UriTemplateString template = "/some/path";

            // when
            var newTemplate = template.AppendQueryParam("query", true);

            // then
            newTemplate.ToString().Should().Be("/some/path{?query*}");
        }

        [Fact]
        public void Can_append_regular_query_param_to_literal_template()
        {
            // given
            UriTemplateString template = "/some/path";

            // when
            var newTemplate = template.AppendQueryParam("query");

            // then
            newTemplate.ToString().Should().Be("/some/path{?query}");
        }

        [Fact]
        public void Can_append_exploded_query_param_to_existing_query()
        {
            // given
            UriTemplateString template = "/some/path{?title}";

            // when
            var newTemplate = template.AppendQueryParam("query", true);

            // then
            newTemplate.ToString().Should().Be("/some/path{?title,query*}");
        }

        [Fact]
        public void Can_append_regular_query_param_to_existing_query()
        {
            // given
            UriTemplateString template = "/some/path{?title}";

            // when
            var newTemplate = template.AppendQueryParam("query");

            // then
            newTemplate.ToString().Should().Be("/some/path{?title,query}");
        }

        [Fact]
        public void Can_append_exploded_query_param_to_template_with_mandatory_query_parameter()
        {
            // given
            UriTemplateString template = "/static/path?required={required}";

            // when
            var newTemplate = template.AppendQueryParam("query", true);

            // then
            newTemplate.ToString().Should().Be("/static/path?required={required}{&query*}");
        }

        [Fact]
        public void Can_append_query_param_to_template_with_mandatory_query_parameter()
        {
            // given
            UriTemplateString template = "/static/path?required={required}";

            // when
            var newTemplate = template.AppendQueryParam("query");

            // then
            newTemplate.ToString().Should().Be("/static/path?required={required}{&query}");
        }

        [Fact]
        public void Can_append_exploded_query_param_to_template_with_query_continuation()
        {
            // given
            UriTemplateString template = "/static/path?required={required}{&opt}";

            // when
            var newTemplate = template.AppendQueryParam("query", true);

            // then
            newTemplate.ToString().Should().Be("/static/path?required={required}{&opt,query*}");
        }

        [Fact]
        public void Can_append_query_param_to_template_with_query_continuation()
        {
            // given
            UriTemplateString template = "/static/path?required={required}{&opt}";

            // when
            var newTemplate = template.AppendQueryParam("query");

            // then
            newTemplate.ToString().Should().Be("/static/path?required={required}{&opt,query}");
        }

        [Theory]
        [InlineData("/static/path{/more,path}", "/static/path{/more,path}{?params*}")]
        [InlineData("/static/path/{more,path}", "/static/path/{more,path}{?params*}")]
        [InlineData("/static/path/{path,explode*}", "/static/path/{path,explode*}{?params*}")]
        [InlineData("/static/path{/path,explode*}", "/static/path{/path,explode*}{?params*}")]
        [InlineData("/static/path{/path}{;path_params}", "/static/path{/path}{;path_params}{?params*}")]
        [InlineData("/static/path{/path}{;path_params*}", "/static/path{/path}{;path_params*}{?params*}")]
        public void Can_append_exploded_query_param_to_template_ending_with_non_query_expression(
            string templateBefore,
            string templateAfter)
        {
            // given
            UriTemplateString template = templateBefore;

            // when
            var newTemplate = template.AppendQueryParam("params", true);

            // then
            newTemplate.ToString().Should().Be(templateAfter);
        }

        [Theory]
        [InlineData("/static/path{/more,path}", "/static/path{/more,path}{?params}")]
        [InlineData("/static/path/{more,path}", "/static/path/{more,path}{?params}")]
        [InlineData("/static/path/{path,explode*}", "/static/path/{path,explode*}{?params}")]
        [InlineData("/static/path{/path,explode*}", "/static/path{/path,explode*}{?params}")]
        [InlineData("/static/path{/path}{;path_params}", "/static/path{/path}{;path_params}{?params}")]
        [InlineData("/static/path{/path}{;path_params*}", "/static/path{/path}{;path_params*}{?params}")]
        public void Can_append_regular_query_param_to_template_ending_with_non_query_expression(
            string templateBefore,
            string templateAfter)
        {
            // given
            UriTemplateString template = templateBefore;

            // when
            var newTemplate = template.AppendQueryParam("params");

            // then
            newTemplate.ToString().Should().Be(templateAfter);
        }
    }
}