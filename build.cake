#addin "Cake.XdtTransform&version=0.12.0"
#tool "xunit.runner.console"

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");
var step = Argument("step", "1");
var method = Argument("method","custom");
var slnName = "./" + method + "/step" + step + "/*.sln";
//*/

var solutionFile = GetFiles(slnName).First();
Information("Solution File {0}", solutionFile);
var solution = new Lazy<SolutionParserResult>(() => ParseSolution(solutionFile));
var distDir = Directory("./dist");
var buildDir = Directory("./build");

Task("Clean-Outputs")
	.Does(() =>
	{
		CleanDirectory(buildDir);
		CleanDirectory(distDir);
	});

Task("NuGetRestore")
	.IsDependentOn("Clean-Outputs")
    .Does(() =>
	{
		NuGetRestore(solutionFile);
		DotNetBuild(solutionFile, settings => settings
			.SetConfiguration(configuration)
			.WithTarget("Rebuild")
			.SetVerbosity(Verbosity.Minimal));
  });

Task("Build")
	.IsDependentOn("NuGetRestore")
	.Does(() =>
	{
		var project = solution.Value.Projects.First();

		var projectName = project.Name + method + "step" + step;
		Information("Publishing {0}", projectName);

		var publishDir = buildDir + Directory(projectName);

		DotNetBuild(project.Path, settings => settings
			.SetConfiguration(configuration)
			.WithProperty("OutDir", MakeAbsolute(publishDir).FullPath + "/")
			.SetVerbosity(Verbosity.Minimal));

		Zip(publishDir, distDir + File(projectName + ".zip"));

	});

Task("Default")
	.IsDependentOn("Build");

RunTarget(target);
