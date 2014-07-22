using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ImgurWallpaperSetter
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Wallpaper.Set(WallpaperRetriever.mostPopularImgurWallpaper(), Wallpaper.Style.Stretched);
        }

        protected override void OnStop()
        {
        }
    }
}
