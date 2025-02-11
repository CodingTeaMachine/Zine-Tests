using Zine.App.Domain.ComicBookInformation.CompressionFormatHandler;

namespace Zine.Tests.App.Domain.ComicBookInformation.CompressionFormatHandler;

/// <summary>
///     TODO: Get one test file with each format and compression algorithm
/// </summary>
public class CompressionFormatFactoryTests
{
	[Fact]
	public void CBZ_Files_Should_Return_ZIP_Format_Test()
	{
		var filePath = Path.Join(Directory.GetCurrentDirectory(), Info.TestFileDirectory, "compression",
			"zip_based_cb.cbz");
		var comicBookFormat = CompressionFormatFactory.GetFromFile(filePath);

		Assert.Equal(CompressionFormat.Zip, comicBookFormat);
	}

	[Fact]
	public void CBR_Files_Should_Return_RAR_Format_Test()
	{
		var filePath = Path.Join(Directory.GetCurrentDirectory(), Info.TestFileDirectory, "compression",
			"rar_based_cb.cbr");
		var comicBookFormat = CompressionFormatFactory.GetFromFile(filePath);

		Assert.Equal(CompressionFormat.Rar, comicBookFormat);
	}
}