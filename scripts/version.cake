public class BuildVersion
{
    public string MajorMinorPatch { get; private set; }
    public string FullVersion { get; private set; }
    public string Suffix { get; private set; }

    public static BuildVersion Calculate(ICakeContext context, BuildParameters parameters)
    {
        if (context == null)
        {
            throw new ArgumentNullException("context");
        }

        var APPVEYOR_BUILD_NUMBER = (context.EnvironmentVariable("APPVEYOR_BUILD_NUMBER") ?? "9999");
        var APPVEYOR_REPO_BRANCH = (context.EnvironmentVariable("APPVEYOR_REPO_BRANCH") ?? "develop");

        string versionSuffix = null;
        string fullVersion = string.Empty;

        context.Information("Calculating Semantic Version");

        context.Information("APPVEYOR_BUILD_NUMBER: " + APPVEYOR_BUILD_NUMBER);
        context.Information("APPVEYOR_REPO_BRANCH: " + APPVEYOR_REPO_BRANCH);

        if(APPVEYOR_REPO_BRANCH == "master")
        {
            versionSuffix = "RC-" + String.Format("{0:0000}", int.Parse(APPVEYOR_BUILD_NUMBER));
        }
        else if(APPVEYOR_REPO_BRANCH == "develop")
        {
            versionSuffix = "beta-" + String.Format("{0:0000}", int.Parse(APPVEYOR_BUILD_NUMBER));
        }
        else
        {
            versionSuffix = "alpha-" + String.Format("{0:0000}", int.Parse(APPVEYOR_BUILD_NUMBER));
        }

        fullVersion = parameters.CurrentVersion + "-" + versionSuffix;

        context.Information(fullVersion);

        return new BuildVersion
        {
            MajorMinorPatch = parameters.CurrentVersion,
            FullVersion = fullVersion,
            Suffix = versionSuffix
        };
    }

    public bool PatchProjectJson(FilePath project)
    {
        var content = System.IO.File.ReadAllText(project.FullPath, Encoding.UTF8);
        var node = Newtonsoft.Json.Linq.JObject.Parse(content);
        if(node["version"] != null)
        {
            node["version"].Replace(FullVersion);
            System.IO.File.WriteAllText(project.FullPath, node.ToString(), Encoding.UTF8);
            return true;
        };
        return false;
    }
}