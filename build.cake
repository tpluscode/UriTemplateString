#tool paket:?package=codecov
#tool paket:?package=gitlink
#addin paket:?package=Cake.Paket
#addin paket:?package=Cake.Codecov
#tool paket:?package=JetBrains.dotCover.CommandLineTools
#tool paket:?package=ReportGenerator&version=4.0.4

var target = Argument("target", "Build");
var configuration = Argument("Configuration", "Debug");

Task("CI")
    .IsDependentOn("Build")
    .IsDependentOn("Codecov");

Task("Build")
    .Does(() => {
        DotNetCoreRestore("UriTemplateString.sln");
    })
    .Does(() => {
        DotNetCoreBuild("UriTemplateString.sln", new DotNetCoreBuildSettings {
            Configuration = configuration
        });
    })
    .DoesForEach(GetFiles("**/UriTemplateString.pdb"), 
        pdb => GitLink3(pdb, new GitLink3Settings {
                RepositoryUrl = "https://github.com/tpluscode/UriTemplateString",
            }));

Task("Codecov")
    .IsDependentOn("Test")
    .Does(() => {
        Codecov("coverage\\cobertura.xml");
    });

Task("Test")
    .IsDependentOn("Build")
    .Does(() => {
        if(DirectoryExists("coverage")) 
            CleanDirectories("coverage"); 
    })
    .Does(() => {
        var settings = new DotNetCoreTestSettings
            {
                Configuration = configuration,
                NoBuild = true,
            };

        DotCoverAnalyse(
           ctx => ctx.DotNetCoreTest(GetFiles("**\\UriTemplateString.Tests.csproj").Single().FullPath, settings),
          "./coverage/dotcover.xml",
          new DotCoverAnalyseSettings {
            ReportType = DotCoverReportType.DetailedXML,
          });
    })
    .Does(() => {
        StartProcess(
          @".\packages\tools\ReportGenerator\tools\net47\ReportGenerator.exe",
          @"-reports:.\coverage\dotcover.xml -targetdir:.\coverage -reporttypes:Cobertura;html -assemblyfilters:-xunit*;-UriTemplateString.Tests;-Newtonsoft.Json;-FluentAssertions");
    });

RunTarget(target);
