using Zine.App.FileHelpers;

namespace Zine.Tests.App.FileHelpers;

public class ComicBookInformationFactoryTests : InputFileHandlerTests
{
	[Fact]
	public void CBs_Without_Multiple_Page_Images_Should_Return_The_Correct_Page_Number()
	{
		const int realNumberOfPages = 36;
		var comicBookPath = Path.Join(Directory.GetCurrentDirectory(), Info.TestFileDirectory, "numberOfPages" , "no_multipage.cbr");

		var factory = new ComicBookInformationFactory();
		var numberOfPages = factory.GetNumberOfPages(comicBookPath);

		Assert.Equal(realNumberOfPages, numberOfPages);
	}

	[Fact]
	public void CBs_With_Multiple_Page_Images_Should_Return_The_Correct_Page_Number()
	{
		const int realNumberOfPages = 24;
		var comicBookPath = Path.Join(Directory.GetCurrentDirectory(), Info.TestFileDirectory, "numberOfPages" , "multipage.cbr");

		var factory = new ComicBookInformationFactory();
		var numberOfPages = factory.GetNumberOfPages(comicBookPath);

		Assert.Equal(realNumberOfPages, numberOfPages);
	}
}
