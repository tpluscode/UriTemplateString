![trail icon](https://raw.githubusercontent.com/tpluscode/UriTemplateString/master/assets/noun_690990.png)

# UriTemplateString [![Build status][av-badge]][build] [![NuGet version][nuget-badge]][nuget-link] [![codecov.io][cov-badge]][cov-link]

Parses [URI Templates](https://tools.ietf.org/html/rfc6570) into a friendly object structure. 

## Introduction

Simply cast a string to `UriTemplateString`.

``` c#
public class PeopleModule : Nancy.Routing.UriTemplates.UriTemplateModule
{
    public PeopleModule()
    {
        // by default you'll be creating typical routes
        Get("person/{id}", p => GetModel(p.id));
            
        // and URI Templates are opt-in
        using(Templates)
        {
            Get("people{;include}{/page}{?name}", p => GetPeople(p.include, p.page, p.name));
        }
    }
}
```

[The stencil print icon](https://thenounproject.com/term/stencil-print/690990) by [Dairy Free Design](https://thenounproject.com/emmaihall/) from [The Noun Project](http://thenounproject.com/)

[av-badge]: https://ci.appveyor.com/api/projects/status/je1g2h91wy7nas8q/branch/master?svg=true
[build]: https://ci.appveyor.com/project/tpluscode78631/uritemplatestring/branch/master
[nuget-badge]: https://badge.fury.io/nu/UriTemplateString.svg
[nuget-link]: https://badge.fury.io/nu/UriTemplateString
[cov-badge]: https://codecov.io/github/tpluscode/UriTemplateString/coverage.svg?branch=master
[cov-link]: https://codecov.io/github/tpluscode/UriTemplateString?branch=master
