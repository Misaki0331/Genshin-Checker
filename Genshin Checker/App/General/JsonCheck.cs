using Genshin_Checker.resource.Languages;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Genshin_Checker.App.General
{
    public class JsonChecker<T>
    {
        public static T Check(string json)
        {
            try
            {
                var root = JsonConvert.DeserializeObject<T>(json);
                return root == null ? throw new ArgumentNullException(Localize.Error_API_Endpoint_RootIsNull) : root;
            }
            catch (Exception ex)
            {
                throw new InvalidDataException(string.Format(Localize.Error_API_Endpoint_JsonParseInvalid, json), ex);
            }
        }
        public static bool IsValid(string? json)
        {
            try
            {
                if (json == null) throw new ArgumentNullException("json is null.");
                Check(json);
                return true;
            }
            catch (Exception e)
            {
                Trace.Write(e);
                return false;
            }
        }
        /// <summary>
        /// jsonをフォーマット化する
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static string format(string json)
        {
            var j = Check(json);
            return JsonConvert.SerializeObject(j, Formatting.Indented);
        }
    }
}
