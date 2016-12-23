![trail icon](https://raw.githubusercontent.com/tpluscode/UriTemplateString/master/assets/noun_690990.png)

# UriTemplateString [![Build status][av-badge]][build] [![NuGet version][nuget-badge]][nuget-link] [![codecov.io][cov-badge]][cov-link] [![codefactor][codefactor-badge]][codefactor-link]

Parses [URI Templates](https://tools.ietf.org/html/rfc6570) into a friendly object structure. 

## Installation

Get from nuget.org

```
install-package UriTemplateString
```

## Usage

Simply cast a string to `UriTemplateString`.

``` c#
var template = (UriTemplateString)"/base/users{/page:2}{?name}";
```

Now you can inspect the structure of the template


``` c#
template.Parts.Legnth == 3;

// access literal parts
var literal = template.Parts[0] as Literal;
literal.ToString() == "/base/users";

// access parts with modifier
var pageSeg = template[1] as Expression;
(pageSeg.Modifier as MaxLength).MaxLength == 2;

// access variables and operator
var query = template.Parts[2] as Expression;
query.Operator.Equals(Operator.QueryComponent);
query.Variables[0].Name == "name";
```

And do simple operations

``` c#
// concatenate templates (and raw strings)
template += "{&rest*}";
// produces /base/users{/page:2}{?name}{&rest*}

// append query
template.AppendQueryParam("rest", explode: true);
// produces /base/users{/page:2}{?name,rest*}
```

## Gotchas

Parsing is implemented using regular expressions so performance can be suboptimal.

Also, currently the expressions are an approximation of the real spec. Quirks possible ahead.

[The stencil print icon](https://thenounproject.com/term/stencil-print/690990) by [Dairy Free Design](https://thenounproject.com/emmaihall/) from [The Noun Project](http://thenounproject.com/)

[av-badge]: https://ci.appveyor.com/api/projects/status/je1g2h91wy7nas8q/branch/master?svg=true
[build]: https://ci.appveyor.com/project/tpluscode78631/uritemplatestring/branch/master
[nuget-badge]: https://badge.fury.io/nu/UriTemplateString.svg
[nuget-link]: https://badge.fury.io/nu/UriTemplateString
[cov-badge]: https://codecov.io/github/tpluscode/UriTemplateString/coverage.svg?branch=master
[cov-link]: https://codecov.io/github/tpluscode/UriTemplateString?branch=master
[codefactor-badge]: https://www.codefactor.io/repository/github/tpluscode/UriTemplateString/badge/master
[codefactor-link]: https://www.codefactor.io/repository/github/tpluscode/UriTemplateString/overview/master
