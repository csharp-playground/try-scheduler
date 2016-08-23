#tool "nuget:?package=NUnit.ConsoleRunner"
#addin "nuget:?package=Cake.Watch"

var solution = "TrySchedule.sln";
var testDll = "TrySchedule.Tests/bin/Debug/TrySchedule.Tests.dll";

Task("Run-Test")
    .Does(() => {
            DotNetBuild(solution);
            NUnit3(testDll);
    });

var target = Argument("target", "default");
RunTarget(target);