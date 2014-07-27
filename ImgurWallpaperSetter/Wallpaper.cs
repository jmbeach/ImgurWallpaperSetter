using Microsoft.Win32;
using System;
using System.IO;
using System.Runtime.InteropServices;

public sealed class Wallpaper
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError=true)]
        private static extern Int32 SystemParametersInfo(
            UInt32 action, UInt32 uParam, String vParam, UInt32 winIni);

        private static readonly UInt32 SPI_SETDESKWALLPAPER = 0x14;
        private static readonly UInt32 SPIF_UPDATEINIFILE = 0x01;
        private static readonly UInt32 SPIF_SENDWININICHANGE = 0x02;

        public static void SetWallpaper(String path)
        {
            System.IO.Stream s = new System.Net.WebClient().OpenRead(path.ToString());
            System.Drawing.Image img = System.Drawing.Image.FromStream(s);
            string tempPath = Path.Combine(Path.GetTempPath(), "wallpaper.bmp");
            ImgurWallpaperSetter.ImgurWallpaperSetter.log(tempPath);
            img.Save(tempPath, System.Drawing.Imaging.ImageFormat.Bmp);
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 1, tempPath,
                SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
            int error = Marshal.GetLastWin32Error();
            ImgurWallpaperSetter.ImgurWallpaperSetter.log("Last error: " + error);
        }
    }