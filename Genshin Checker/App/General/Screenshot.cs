﻿using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.App.General
{
    public static class ScreenShot
    {
        public static async Task<string> SaveToLocation(string e)
        {
            var savepath = Option.Instance.ScreenShot.SaveFilePath;
            var format = Option.Instance.ScreenShot.SaveFileFormat;
            var uid = await GameApp.CurrentUID();
            format = await GenerateFormat(format);
            Trace.WriteLine(uid);
            Trace.WriteLine(format);
            var path = Path.GetFullPath(Path.Combine(savepath, format + Option.Instance.ScreenShot.SaveFileFormatType));
            if (!Directory.Exists(Path.GetDirectoryName(path)))
            {
                var path2 = Path.GetDirectoryName(path);
                if (path2 != null) Directory.CreateDirectory(path2);
            }
            Exception? ex = null;
            Stopwatch timeout = new();
            timeout.Start();
            while (timeout.ElapsedMilliseconds < 5000)
            {
                try
                {
                    switch (Option.Instance.ScreenShot.SaveFileFormatType)
                    {
                        case ".png":
                            File.Copy(e, path);
                            break;
                        case ".jpg":
                            Bitmap image = new Bitmap(e);
                            image.Save(path, ImageFormat.Jpeg);
                            image.Dispose();
                            break;
                        case ".tiff":
                            image = new Bitmap(e);
                            image.Save(path, ImageFormat.Tiff);
                            image.Dispose();
                            break;
                    }
                    ex = null;
                    break;
                }
                catch (IOException ex2) when ((ex2.HResult & 0x0000FFFF) == 32)
                {
                    ex = ex2;
                    await Task.Delay(100);
                }
                catch (Exception ex2)
                {
                    ex = ex2;
                    await Task.Delay(100);
                }
            }
            if (ex != null) throw ex;
            if (Option.Instance.ScreenShot.IsSaveAfterDelete) File.Delete(e);
            return path;
        }
        public static async Task<string> GenerateFormat(string format)
        {
            var uid = await GameApp.CurrentUID();
            var time = DateTime.Now;
            long unix = DateTime.UtcNow.Ticks / 10000000;
            format = format.Replace("<UID>", $"{uid}");

            format = format.Replace("<DATE>", $"{time:yyyy-MM-dd}");
            format = format.Replace("<TIME>", $"{time:HH-mm-ss}");

            format = format.Replace("<APM>", $"{(time.Hour < 12 ? "A" : "P")}M");
            format = format.Replace("<APM->", $"{(time.Hour < 12 ? "a" : "p")}m");
            format = format.Replace("<24H>", $"{time:HH}");
            format = format.Replace("<12H>", $"{time:hh}");
            format = format.Replace("<MIN>", $"{time:mm}");
            format = format.Replace("<SEC>", $"{time:ss}");

            format = format.Replace("<YEAR>", $"{time:yyyy}");
            format = format.Replace("<MONTH>", $"{time:MM}");
            format = format.Replace("<DAY>", $"{time:dd}");
            string[] dow = new string[] { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
            format = format.Replace("<DOW>", $"{dow[(int)time.DayOfWeek]}");
            format = format.Replace("<DOW+>", $"{dow[(int)time.DayOfWeek].ToUpper()}");
            format = format.Replace("<DOW->", $"{dow[(int)time.DayOfWeek].ToLower()}");
            string[] monthname = new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            format = format.Replace("<MONTHNAME>", $"{monthname[time.Month-1]}");
            format = format.Replace("<MONTHNAME+>", $"{monthname[time.Month-1].ToUpper()}");
            format = format.Replace("<MONTHNAME->", $"{monthname[time.Month-1].ToLower()}");

            format = format.Replace("<MONTHNAME3>", $"{monthname[time.Month - 1][..3]}");
            format = format.Replace("<MONTHNAME3+>", $"{monthname[time.Month - 1][..3].ToUpper()}");
            format = format.Replace("<MONTHNAME3->", $"{monthname[time.Month - 1][..3].ToLower()}");
            format = format.Replace("<UNIX>", $"{unix}");
            format = format.Replace("<FF>", $"{time:ff}");
            format = format.Replace("<FFF>", $"{time:fff}");
            format = format.Replace("<FFFF>", $"{time:ffff}");
            format = format.Replace("<FFFFF>", $"{time:fffff}");
            format = format.Replace("<FFFFFF>", $"{time:ffffff}");
            format = format.Replace("<FFFFFFF>", $"{time:fffffff}");

            return format;
        }
        public static async Task<string> SetFileFormat(string format)
        {
            var invalid = Path.GetInvalidFileNameChars();
            if (format.Contains("\\/") || format.Contains("/\\") || format.Contains("//") || format.Contains("\\\\")
                || format.Contains("\\ ") || format.Contains("/ ") || format.Contains(" \\") || format.Contains(" /"))
                return "パスの区切りを連続で2つ以上にすることはできません。";
            if (format.StartsWith(" "))
                return "先頭文字にスペースは使用できません。";
            if (format.EndsWith("/") || format.EndsWith("\\"))
                return "末尾文字にパスを区切りを使用することはできません。";

            if((await GenerateFormat(format)).Replace("\\", "_").Replace("/", "_").IndexOfAny(invalid) >= 0)
            {
                return "パスに使用できない文字が含まれています。";
            }
            else
            {
                Option.Instance.ScreenShot.SaveFileFormat = format;
                Registry.SetValue("Config\\Setting", "ScreenShotSaveFileFormat", $"{format}");
                return "";
            }
        }
    }
}
