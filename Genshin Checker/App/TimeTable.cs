using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Compression;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Genshin_Checker.App
{
    public class TimeTable
    {
        static DayCache DayCacheData = new DayCache();
        class DayCache
        {
            public DateTime date = DateTime.MinValue;
            public bool IsDateEqual(DateTime diff)
            {
                if (date.Year == diff.Year && date.Month == diff.Month && date.Day == diff.Day) return true;
                return false;
            }
            public string raw = "";
        }
        public static string LoadDate(DateTime date)
        {
            var data = Registry.GetValue($"TimeTable\\{date.Year}\\{date.Month:00}\\{date.Day:00}", "PlayAlias");
            try
            {
                if (data == null) throw new FileNotFoundException();

                var raw = StringFromBase64Comp(data.ToString());
                if (raw.Length != 86400) throw new InvalidCastException();
                return raw;
            }
            catch
            {
                string empty1 = "";
                string empty2 = "";
                string empty3 = "";
                for (int i = 0; i < 60; i++) empty1 += " ";
                for (int i = 0; i < 60; i++) empty2 += empty1;
                for (int i = 0; i < 24; i++) empty3 += empty2;
                return empty3;
            }
        }
        public static Task<string> LoadDateLocal(DateTime date)
        {
            return Task.Run(async() =>
            {
                var rawdata = Task.Run(() => LoadDate(date));
                var timezone = TimeZoneInfo.Local.GetUtcOffset(DateTime.Now);
                int offset = 0;
                string result = "";
                if (timezone > TimeSpan.Zero)
                {
                    var spare = Task.Run(() => LoadDate(date.AddDays(-1)));
                    result = await spare + await rawdata;
                    offset = 86400 - (int)timezone.TotalSeconds;
                    result = result.Substring(offset, 86400);
                }
                else if (timezone < TimeSpan.Zero)
                {
                    var spare = Task.Run(() => LoadDate(date.AddDays(1)));
                    result = await rawdata + await spare;
                    offset = -(int)timezone.TotalSeconds;
                    result = result.Substring(offset, 86400);
                }
                return result;
            });
        }
        public static bool SaveDate(DateTime date,string data)
        {
            if (data.Length != 86400) return false;
            var compressed = Base64FromStringComp(data);
            Registry.SetValue($"TimeTable\\{date.Year}\\{date.Month:00}\\{date.Day:00}", "PlayAlias",compressed);
            return true;
        }
        public static bool SavePoint(DateTime time, string State)
        {
            if (State.Length != 1) throw new InvalidDataException();
            try
            {
                if (!DayCacheData.IsDateEqual(time))
                {
                    DayCacheData.raw=LoadDate(time);
                    DayCacheData.date = time;
                }
                var data = DayCacheData.raw;
                int cnt = (time.Hour * 60 + time.Minute) * 60 + time.Second;
                data = ReplaceChar(data, cnt, State);
                DayCacheData.raw = data;
                SaveDate(time, data);
                return true;
            }catch
            {
            }
            return false;
        }
        static string ReplaceChar(string original, int index, string newChar)
        {
            //3つ目の引数が1文字以外であればInvalidDataExceptionをスローする
            if (newChar.Length != 1)
            {
                throw new InvalidDataException("The third argument must be a single character.");
            }
            //2つ目の引数が範囲外であればIndexOutOfRangeExceptionをスローする
            if (index < 0 || index >= original.Length)
            {
                throw new IndexOutOfRangeException("The second argument must be a valid index of the original string.");
            }
            //StringBuilderクラスを使って文字を書き換える
            StringBuilder sb = new StringBuilder(original);
            sb[index] = newChar[0];
            //新しいstringを返す
            return sb.ToString();
        }
        static string Base64FromStringComp(string st)
        {
            #region 文字列を圧縮

            // 文字列をバイト配列に変換します 
            byte[] source = Encoding.UTF8.GetBytes(st);

            // 入出力用のストリームを生成します 
            MemoryStream ms = new MemoryStream();
            DeflateStream CompressedStream = new DeflateStream(ms, CompressionMode.Compress, true);
            // ストリームに圧縮するデータを書き込みます 
            CompressedStream.Write(source, 0, source.Length);
            CompressedStream.Close();
            // 圧縮されたデータを バイト配列で取得します 
            byte[] destination = ms.ToArray();
            #endregion

            #region 圧縮したバイナリをBASE64へ変換
            //Base64で文字列に変換
            string base64String;
            base64String = System.Convert.ToBase64String(destination, Base64FormattingOptions.InsertLineBreaks);
            #endregion

            return base64String;
        }

        //------------------------------------------
        //BASE64文字列を戻し解凍の上で文字列に変換して返す
        //
        //------------------------------------------
        static string StringFromBase64Comp(string st)
        {
            #region BASE64文字列を圧縮バイナリへ戻す
            byte[] bs = System.Convert.FromBase64String(st);
            #endregion

            #region 圧縮バイナリを文字列へ解凍する

            // 入出力用のストリームを生成します 
            MemoryStream ms = new MemoryStream(bs);
            MemoryStream ms2 = new MemoryStream();
            DeflateStream CompressedStream = new DeflateStream(ms, CompressionMode.Decompress);
            //　MemoryStream に展開します 
            while (true)
            {
                int rb = CompressedStream.ReadByte();
                // 読み終わったとき while 処理を抜けます 
                if (rb == -1)
                {
                    break;
                }
                // メモリに展開したデータを読み込みます 
                ms2.WriteByte((byte)rb);
            }

            string result = Encoding.UTF8.GetString(ms2.ToArray());
            #endregion

            return result;
        }
    }
}
