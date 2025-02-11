namespace Zine.Tests;

public static class Info
{
	public const string TestFileDirectory = "Resources";
	public static string TestOutputFileDirectory => Path.Join(Path.GetTempPath(), "Output");

	public static void CreateOutputDirectoryIfNotExists()
	{
		if (!Directory.Exists(TestOutputFileDirectory)) Directory.CreateDirectory(TestOutputFileDirectory);
	}

	public static void DeleteOutputDirectoryIfExists()
	{
		if (Directory.Exists(TestOutputFileDirectory)) Directory.Delete(TestOutputFileDirectory, true);
	}
}