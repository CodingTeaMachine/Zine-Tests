using Zine.App.Domain.ComicBookInformation.CompressionFormatHandler;

namespace Zine.Tests.App.Domain.ComicBookInformation.CompressionFormatHandler;

public class CompressionFormatHandlerTests : InputFileHandlerTests
{
	[Fact]
	public void Inputting_A_Zip_Compressed_Comic_Book_Should_Extract_Cover_Image_Into_Output_Directory()
	{
		const string coverImageName = "artifacts_00_01.jpg";
		var filePath = Path.Join(Directory.GetCurrentDirectory(), Info.TestFileDirectory, "zip_based_cb.cbz");
		new CompressedFileHandler(filePath, Info.TestOutputFileDirectory).SaveThumbnailToDisc(coverImageName, "test.jpg");

		Assert.Single(Directory.GetFiles(Info.TestOutputFileDirectory));
	}

	[Fact]
	public void Inputting_A_Rar_Compressed_Comic_Book_Should_Extract_Cover_Image_Into_Output_Directory()
	{
		const string coverImageName = "Artifacts 01 (Kingpin) pg01.jpg";
		var filePath = Path.Join(Directory.GetCurrentDirectory(), Info.TestFileDirectory, "rar_based_cb.cbr");
		new CompressedFileHandler(filePath, Info.TestOutputFileDirectory).SaveThumbnailToDisc(coverImageName, "test.jpg");

		Assert.Single(Directory.GetFiles(Info.TestOutputFileDirectory));
	}
}
