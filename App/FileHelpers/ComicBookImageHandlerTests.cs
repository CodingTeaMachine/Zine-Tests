using Zine.App.Domain.ComicBookPageInformation;

namespace Zine.Tests.App.FileHelpers;

public class ComicBookImageHandlerTests : InputFileHandlerTests
{
	[Fact]
	public void CBs_Without_Multiple_Page_Images_Should_Return_The_Correct_Page_Number()
	{
		const int realNumberOfPages = 36;
		const int comicBookId = 1;
		var comicBookPath = Path.Join(Directory.GetCurrentDirectory(), Info.TestFileDirectory, "numberOfPages" , "no_multipage.cbr");

		var pages = PageInfoListFactory.GetPageInfoList(comicBookPath, comicBookId);

		Assert.Equal(realNumberOfPages, pages.Last().PageNumberEnd);
	}

	[Fact]
	public void CBs_With_Multiple_Page_Images_Should_Return_The_Correct_Page_Number()
	{
		const int realNumberOfPages = 24;
		const int comicBookId = 1;
		var comicBookPath = Path.Join(Directory.GetCurrentDirectory(), Info.TestFileDirectory, "numberOfPages" , "multipage.cbr");

		var pages = PageInfoListFactory.GetPageInfoList(comicBookPath, comicBookId);

		Assert.Equal(realNumberOfPages, pages.Last().PageNumberEnd);
	}
}
