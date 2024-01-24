using Genshin_Checker.resource.Languages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
