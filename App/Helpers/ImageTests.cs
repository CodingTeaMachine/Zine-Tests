using SharpCompress.Archives;
using Zine.App.Helpers;

namespace Zine.Tests.App.Helpers;

public class ImageTests
{

	[Fact]
	public void Resizing_An_Image_Returns_The_Right_Size()
	{
		var filePath = Path.Join(Directory.GetCurrentDirectory(), Info.TestFileDirectory, "compression",
			"zip_based_cb.cbz");

		using var archive = ArchiveFactory.Open(filePath);
		var imageToUse = archive.Entries.First(entry => Path.GetExtension(entry.Key) is ".jpg" or ".jpeg" or ".png");
		const int width = 100;
		const int height = 100;

		var result = Image.GetResizedImage(imageToUse, width, height);

		using var ms = new MemoryStream(result);
		var image = SkiaSharp.SKBitmap.Decode(ms);

		Assert.Equal(width, image.Width);
		Assert.Equal(height, image.Height);
	}

}
