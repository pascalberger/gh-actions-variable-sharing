using Cake.Common.Build;
using Cake.Core;
using Cake.Frosting;

public static class Program
{
    public static int Main(string[] args)
    {
        return new CakeHost()
            .UseContext<BuildContext>()
            .Run(args);
    }
}

public class BuildContext(ICakeContext context) : FrostingContext(context)
{
}

[TaskName("Default")]
public class DefaultTask : FrostingTask<BuildContext>
{
    public override void Run(BuildContext context)
    {
       context.BuildSystem().GitHubActions.Commands.SetOutputParameter("FullSemVer", "1.2.3-alpha42");
    }
}