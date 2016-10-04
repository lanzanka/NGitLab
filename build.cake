// Install addins.
#addin "nuget:https://www.nuget.org/api/v2?package=Newtonsoft.Json&version=9.0.1"
#addin "nuget:https://www.nuget.org/api/v2?package=Cake.Coveralls&version=0.2.0"

// Install tools.
#tool "nuget:https://www.nuget.org/api/v2?package=GitReleaseNotes"
#tool "nuget:https://www.nuget.org/api/v2?package=GitVersion.CommandLine&version=3.6.2"
#tool "nuget:https://www.nuget.org/api/v2?package=OpenCover&version=4.6.519"
#tool "nuget:https://www.nuget.org/api/v2?package=ReportGenerator&version=2.4.5"
#tool "nuget:https://www.nuget.org/api/v2?package=coveralls.io&version=1.3.4"

// Load other scripts.
#load "./scripts/parameters.cake"

//////////////////////////////////////////////////////////////////////
// PARAMETERS
//////////////////////////////////////////////////////////////////////
BuildParameters parameters = BuildParameters.GetParameters(Context);

//////////////////////////////////////////////////////////////////////
// SETUP / TEARDOWN
//////////////////////////////////////////////////////////////////////
Setup(context =>
{
    parameters.Initialize(context);

    if(parameters.IsRunningOnAppVeyor)
    {
        //Update build version
        AppVeyor.UpdateBuildVersion(parameters.Version.FullVersion);
    }

    Information("Building version {0} of NGitLab.", parameters.Version.FullVersion);
});

Teardown(context =>
{
    // Executed AFTER the last task.
    Information("Finished building version {0} of NGitLab.", parameters.Version.FullVersion);
});

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
	.Does(()=>
{
	CleanDirectories("./build");
    CleanDirectories("**/bin");
    CleanDirectories("**/obj");
});

Task("Patch-Project-Json")
    .IsDependentOn("Clean")
    .WithCriteria(() => parameters.IsRunningOnAppVeyor)
    .Does(() =>
{
    var projects = GetFiles("./NGitLab/**/project.json");
    foreach(var project in projects)
    {
        if(!parameters.Version.PatchProjectJson(project)) {
            Warning("No version specified in {0}.", project.FullPath);
        }
    }
});

Task("Package-Restore")
    .IsDependentOn("Clean")
    .Does(() =>
{
    DotNetCoreRestore("./NGitLab/");
});

Task("Build")
    .IsDependentOn("Patch-Project-Json")
    .IsDependentOn("Package-Restore")
    .Does(() =>
{
	var projects = GetFiles("./**/*.xproj");
    foreach(var project in projects)
    {
        DotNetCoreBuild(project.GetDirectory().FullPath, new DotNetCoreBuildSettings {
            Configuration = parameters.Configuration
        });
    }
});

Task("Check-Build-Folder-Exists")
  .IsDependentOn("Build")
  .Does(() =>
{
	EnsureDirectoryExists("./build");
});

Task("Run-Tests")
    .IsDependentOn("Check-Build-Folder-Exists")
    .Does(() =>
{
	var projects = GetFiles("./NGitLab/**/*.Tests.xproj");
	foreach(var project in projects)
    {
        Action<ICakeContext> testAction = tool => {
				tool.DotNetCoreTest(project.GetDirectory().FullPath, new DotNetCoreTestSettings {
					Configuration = parameters.Configuration,
					NoBuild = true,
					Verbose = false,
					ArgumentCustomization = args =>
						args.Append("-xml")
                        .Append("./build/" + project.GetFilenameWithoutExtension() + ".xml")
                        .Append("-notrait \"Category=Integration\"")
				});
			};

		if(IsRunningOnWindows())
		{
			OpenCover(testAction,
				"./build/OpenCover.xml",
				new OpenCoverSettings {
					OldStyle = true,
					ReturnTargetCodeOffset = 0
				}
					.WithFilter("+[*]* -[xunit.*]* -[*.Tests]* ")
					.ExcludeByFile("*/*Designer.cs;*/*.g.cs;*/*.g.i.cs"));
		}
        else
        {
            testAction(Context);
        }
	}

	// Generate the HTML version of the Code Coverage report if the XML file exists
    if(FileExists("./build/OpenCover.xml"))
    {
        ReportGenerator("./build/OpenCover.xml", "./build/CoverageReport");
    }
});

Task("Create-Release-Notes")
    .IsDependentOn("Run-Tests")
    .WithCriteria(() => parameters.IsRunningOnWindows)
    .Does(() =>
{
     var releaseNotesExitCode = StartProcess(@"tools\GitReleaseNotes\tools\gitreleasenotes.exe",
     new ProcessSettings
      {
        Arguments = ". /o ./build/releasenotes.md"
      });

      if(!System.IO.File.Exists("./build/releasenotes.md"))
      {
          Information("Did not create release notes!!");
      }
});

Task("Create-NuGet-Packages")
  .IsDependentOn("Create-Release-Notes")
  .Does(() =>
{
    DotNetCorePack("./NGitLab/src/NGitLab", new DotNetCorePackSettings {
          Configuration = parameters.Configuration,
          OutputDirectory = "./build",
          NoBuild = true
    });
});

Task("Upload-Coverage-Report")
  .IsDependentOn("Create-NuGet-Packages")
  .WithCriteria(() => FileExists("./build/OpenCover.xml"))
  .WithCriteria(() => parameters.IsRunningOnAppVeyor)
  .Does(() =>
  {
    var coverallsToken = Argument<string>("coverallsToken");
    CoverallsIo("./build/OpenCover.xml", new CoverallsIoSettings()
    {
        RepoToken = coverallsToken
    });
  });

Task("Zip-Files")
    .IsDependentOn("Upload-Coverage-Report")
    .Does(() =>
{
    // CodeCoverage
    var codeCoverage = GetFiles("./build/CoverageReport/*");
    Zip("./build/", "./build/CoverageReport.zip", codeCoverage);
});

Task("Upload-AppVeyor-Artifacts")
    .IsDependentOn("Zip-Files")
    .WithCriteria(() => parameters.IsRunningOnAppVeyor)
    .Does(() =>
{
  AppVeyor.UploadArtifact("./build/CoverageReport.zip");
  AppVeyor.UploadArtifact("./build/releasenotes.md");
  AppVeyor.UploadArtifact("./build/NGitLab." + parameters.Version.FullVersion + ".nupkg");
});

Task("Default")
  .IsDependentOn("Upload-AppVeyor-Artifacts");

RunTarget(parameters.Target);
