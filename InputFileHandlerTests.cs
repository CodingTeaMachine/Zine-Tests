namespace Zine.Tests;

public class InputFileHandlerTests : IDisposable
{
	public InputFileHandlerTests()
	{
		Info.CreateOutputDirectoryIfNotExists();
	}

	public void Dispose()
	{
		Info.DeleteOutputDirectoryIfExists();
	}
}