using Zine.App.FileHelpers;

namespace Zine.Tests.App.Domain.ComicBookInformation.CompressionFormatHandler;

public class CompressionFormatHandlerTests : InputFileHandlerTests
{
	[Fact]
	public void Inputting_A_Zip_Compressed_Comic_Book_Should_Extract_Cover_Image_Into_Output_Directory()
	{
		const string coverImageName = "artifacts_00_01.jpg";
		var filePath = Path.Join(Directory.GetCurrentDirectory(), Info.TestFileDirectory, "compression", "zip_based_cb.cbz");

		new ComicBookImageHandler().SaveThumbnailToDisc(filePath, coverImageName, "test.jpg", Info.TestOutputFileDirectory);

		Assert.Single(Directory.GetFiles(Info.TestOutputFileDirectory));
	}

	[Fact]
	public void Inputting_A_Rar_Compressed_Comic_Book_Should_Extract_Cover_Image_Into_Output_Directory()
	{
		const string coverImageName = "Artifacts 01 (Kingpin) pg01.jpg";
		var filePath = Path.Join(Directory.GetCurrentDirectory(), Info.TestFileDirectory, "compression" , "rar_based_cb.cbr");
		new ComicBookImageHandler().SaveThumbnailToDisc(filePath, coverImageName, "test.jpg", Info.TestOutputFileDirectory);

		Assert.Single(Directory.GetFiles(Info.TestOutputFileDirectory));
	}
}
