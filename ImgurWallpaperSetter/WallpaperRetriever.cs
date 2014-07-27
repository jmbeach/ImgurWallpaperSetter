using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;
using System.Threading.Tasks;
using System.Web;
using HtmlAgilityPack;

namespace ImgurWallpaperSetter
{
    public class WallpaperRetriever
    {
        public static String imgurTopWallpapersUri = "http://imgur.com/r/wallpapers/top/week";
        static WebClient client = new WebClient();
        public static String downloadImgurWallpapersPageAsString()
        {
            String url = client.DownloadString(imgurTopWallpapersUri);
            return url;
        }
        public static HtmlDocument imgurToHtml()
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(downloadImgurWallpapersPageAsString());
            return doc;
        }
        public static Uri mostPopularImgurWallpaper() {
            var doc = WallpaperRetriever.imgurToHtml();
            var list = doc.DocumentNode.Descendants("div").Where(d =>
    d.Attributes.Contains("class") && d.Attributes["class"].Value.Split(' ').Any(b => b.Equals("post"))
);
            var first = list.ToArray()[0].FirstChild.NextSibling;
            String href = (String)first.Attributes["href"].Value;
            String[] urlParts = href.Split("/"[0]);
            String imgCode = urlParts[urlParts.Length - 1];
            String imgUrl = String.Format("http://i.imgur.com/{0}.jpeg", imgCode);
            Uri imgUri = new Uri(imgUrl);
            return imgUri;
        }
    }
}
