using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgurWallpaperSetter
{
    public class HelloJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            Uri imageUrl = WallpaperRetriever.mostPopularImgurWallpaper();
            Wallpaper.SetWallpaper(imageUrl.AbsoluteUri);
        }
    }
}
