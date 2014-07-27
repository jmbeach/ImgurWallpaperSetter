using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImgurWallpaperSetter;
using HtmlAgilityPack;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class WallpaperRetrieverTest
    {
        [TestMethod]
        public void testDownloadImgur()
        {
            //WallpaperScheduler.ScheduleWallpaperFetch(DateTime.Now.Hour, DateTime.Now.Hour);
            //Wallpaper.Set(WallpaperRetriever.mostPopularImgurWallpaper(), Wallpaper.Style.Stretched);
            Uri imageUrl = WallpaperRetriever.mostPopularImgurWallpaper();
            Wallpaper.SetWallpaper(imageUrl.AbsoluteUri);
        }
    }
}
