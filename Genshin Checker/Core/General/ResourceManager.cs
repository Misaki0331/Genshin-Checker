using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Resources;
using System.Windows;
using System.Windows.Media.Imaging;
using static Genshin_Checker.Core.Game.ProcessTime;

namespace Genshin_Checker
{
    public class ResourceManager
    {
        private static Uri GetFullPath(string path)
        {
            if (path.Contains("\\")) path = path.Replace("\\", "/");
            if (path.StartsWith("/")) path = path.Substring(1);
            return new($"/Resource/{path}",UriKind.Relative);
        }
        public static Stream GetStream(string path)
        {
            return System.Windows.Application.GetResourceStream(
                GetFullPath(path)).Stream;
        }
        public static BitmapImage? GetBitmapImage(string path)
        {
            var info = GetStream(path);
            BitmapImage? result;
            if (info != null)
            {
                using (Stream stream = info)
                {
                    if (stream != null)
                    {
                        result = new BitmapImage();

                        result.BeginInit();
                        result.StreamSource = stream;
                        result.CacheOption = BitmapCacheOption.OnLoad;
                        result.EndInit();
                        return result;
                    }
                }
            }
            return null;
        }
    }
}
