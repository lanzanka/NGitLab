#load "./version.cake"

public class BuildParameters
{
    public string Target { get; private set; }
    public string Configuration { get; private set; }
    public string CurrentVersion { get; private set; }

    public bool IsRunningOnUnix { get; private set; }
    public bool IsRunningOnWindows { get; private set; }
    public bool IsRunningOnAppVeyor { get; private set; }
    public bool IsPullRequest { get; private set; }

    public BuildVersion Version { get; private set; }

    public static BuildParameters GetParameters(ICakeContext context)
    {
        if (context == null)
        {
            throw new ArgumentNullException("context");
        }

        var buildSystem = context.BuildSystem();

        return new BuildParameters {
            Target = context.Argument("target", "Default"),
            Configuration = context.Argument("configuration", "Release"),
            CurrentVersion = "2.0.0",          
            IsRunningOnUnix = context.IsRunningOnUnix(),
            IsRunningOnWindows = context.IsRunningOnWindows(),
            IsRunningOnAppVeyor = buildSystem.AppVeyor.IsRunningOnAppVeyor,
            IsPullRequest = buildSystem.AppVeyor.Environment.PullRequest.IsPullRequest,
        };
    }

    public void Initialize(ICakeContext context)
    {
        Version = BuildVersion.Calculate(context, this);
    }
}