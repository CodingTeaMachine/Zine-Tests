using Zine.App.Domain.ComicBookPageInformation;

namespace Zine.Tests.App.Domain.ComicBookPageInformation;

public class PageInfoListFactoryTests
{

	[Fact]
	public void Basic_Enumeration_Should_Return_The_Pages_In_The_Right_Order()
	{
		const int comicBookId = 1;
		const int normalPageCount = 29;
		const string expectedCoverImageName = "artifacts_00_01.jpg";

		var filePath = Path.Join(Directory.GetCurrentDirectory(), Info.TestFileDirectory, "pageNamingConvention",
			"enumeration.cbz");

		var result = PageInfoListFactory.GetPageInfoList(filePath, comicBookId);
		var cover = result.FirstOrDefault(pageInfo => pageInfo.PageType == PageType.Cover);
		var coverInside = result.FirstOrDefault(pageInfo => pageInfo.PageType == PageType.CoverInside);
		var backCover = result.FirstOrDefault(pageInfo => pageInfo.PageType == PageType.BackCover);
		var backCoverInside = result.FirstOrDefault(pageInfo => pageInfo.PageType == PageType.BackCoverInside);
		var normalPages = result.Where(pageInfo => pageInfo.PageType is PageType.Single or PageType.Double);

		Assert.NotNull(cover);
		Assert.Equal(expectedCoverImageName, cover.PageFileName);

		Assert.Null(coverInside);
		Assert.Null(backCover);
		Assert.Null(backCoverInside);

		Assert.Equal(normalPageCount, normalPages.Count());
	}

	[Fact]
	public void Inside_Cover_Should_Return_The_Right_Page()
	{
		const int comicBookId = 1;
		const int normalPageCount = 20;
		const string expectedCoverImageName = "the_Darkness_n28-c01.jpg";
		const string expectedCoverInsideImageName = "the_Darkness_n28-ic01.jpg";
		var filePath = Path.Join(Directory.GetCurrentDirectory(), Info.TestFileDirectory, "pageNamingConvention",
			"cover and cover  inside.cbz");

		var result = PageInfoListFactory.GetPageInfoList(filePath, comicBookId);

		var cover = result.FirstOrDefault(pageInfo => pageInfo.PageType == PageType.Cover);
		var coverInside = result.FirstOrDefault(pageInfo => pageInfo.PageType == PageType.CoverInside);
		var backCover = result.FirstOrDefault(pageInfo => pageInfo.PageType == PageType.BackCover);
		var backCoverInside = result.FirstOrDefault(pageInfo => pageInfo.PageType == PageType.BackCoverInside);
		var normalPages = result.Where(pageInfo => pageInfo.PageType is PageType.Single or PageType.Double);

		Assert.NotNull(cover);
		Assert.Equal(expectedCoverImageName, cover.PageFileName);

		Assert.NotNull(coverInside);
		Assert.Equal(expectedCoverInsideImageName, coverInside.PageFileName);

		Assert.Null(backCover);
		Assert.Null(backCoverInside);

		Assert.Equal(normalPageCount, normalPages.Count());
	}

	[Fact]
	public void All_Pages_Should_Return_The_Right_Type()
	{
		const int comicBookId = 1;
		const int normalPageCount = 36;
		const string expectedCoverImageName = "Tales_of_the_Darkness_0.5_c01.jpg";
		const string expectedCoverInsideImageName = "Tales_of_the_Darkness_0.5_ic1.jpg";
		const string expectedBackCoverImageName = "Tales_of_the_Darkness_0.5_c02.jpg";
		const string expectedBackCoverInsideImageName = "Tales_of_the_Darkness_0.5_ic2.jpg";
		var filePath = Path.Join(Directory.GetCurrentDirectory(), Info.TestFileDirectory, "pageNamingConvention",
			"both covers with insides.cbz");

		var result = PageInfoListFactory.GetPageInfoList(filePath, comicBookId);

		var cover = result.FirstOrDefault(pageInfo => pageInfo.PageType == PageType.Cover);
		var coverInside = result.FirstOrDefault(pageInfo => pageInfo.PageType == PageType.CoverInside);
		var backCover = result.FirstOrDefault(pageInfo => pageInfo.PageType == PageType.BackCover);
		var backCoverInside = result.FirstOrDefault(pageInfo => pageInfo.PageType == PageType.BackCoverInside);
		var normalPages = result.Where(pageInfo => pageInfo.PageType is PageType.Single or PageType.Double);

		Assert.NotNull(cover);
		Assert.Equal(expectedCoverImageName, cover.PageFileName);

		Assert.NotNull(coverInside);
		Assert.Equal(expectedCoverInsideImageName, coverInside.PageFileName);

		Assert.NotNull(backCover);
		Assert.Equal(expectedBackCoverImageName, backCover.PageFileName);

		Assert.NotNull(backCoverInside);
		Assert.Equal(expectedBackCoverInsideImageName, backCoverInside.PageFileName);

		Assert.Equal(normalPageCount, normalPages.Count());
	}

	[Fact]
	public void Explicit_Inside_Cover_Should_Return_The_Right_Page()
	{
		const int comicBookId = 1;
		const int normalPageCount = 22;
		const string expectedCoverImageName = "Tales_of_the_Darkness_1_c01.jpg";
		const string expectedCoverInsideImageName = "Tales_of_the_Darkness_1_ifc.jpg";
		var filePath = Path.Join(Directory.GetCurrentDirectory(), Info.TestFileDirectory, "pageNamingConvention",
			"explicit cover inside.cbz");

		var result = PageInfoListFactory.GetPageInfoList(filePath, comicBookId);

		var cover = result.FirstOrDefault(pageInfo => pageInfo.PageType == PageType.Cover);
		var coverInside = result.FirstOrDefault(pageInfo => pageInfo.PageType == PageType.CoverInside);
		var backCover = result.FirstOrDefault(pageInfo => pageInfo.PageType == PageType.BackCover);
		var backCoverInside = result.FirstOrDefault(pageInfo => pageInfo.PageType == PageType.BackCoverInside);
		var normalPages = result.Where(pageInfo => pageInfo.PageType is PageType.Single or PageType.Double);

		Assert.NotNull(cover);
		Assert.Equal(expectedCoverImageName, cover.PageFileName);

		Assert.NotNull(coverInside);
		Assert.Equal(expectedCoverInsideImageName, coverInside.PageFileName);

		Assert.Null(backCover);
		Assert.Null(backCoverInside);

		Assert.Equal(normalPageCount, normalPages.Count());
	}

}
