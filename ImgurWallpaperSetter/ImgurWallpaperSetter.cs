using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;

namespace ImgurWallpaperSetter
{
    public partial class ImgurWallpaperSetter : ServiceBase
    {


        public static void log(String text)
        {
            System.Diagnostics.EventLog appLog =
    new System.Diagnostics.EventLog();
            appLog.Source = "ImgurWallpaperSetter";
            appLog.WriteEntry(text);
        }

        public ImgurWallpaperSetter()
        {
            InitializeComponent();
        }


        protected override void OnStart(string[] args)
        {


            WallpaperScheduler.ScheduleWallpaperFetch(DateTime.Now.Hour, DateTime.Now.Minute + 1);
            //Debugger.Launch();
            //Uri imageUrl = WallpaperRetriever.mostPopularImgurWallpaper();
            //log(imageUrl.AbsoluteUri);
            //Wallpaper.SetWallpaper(imageUrl.AbsoluteUri);
        }

        protected override void OnStop()
        {
        }

    }
    
}
