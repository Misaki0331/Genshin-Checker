using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Genshin_Checker.Model.Misaki_chan.HoYoContent
{
    //API URL : https://dynamic-api.misaki-chan.world/genshin/bbs/ja
    public class Root
    {
        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; set; }
        [JsonPropertyName("result")]
        public List<Result> Results { get; set; } = new();

    }
    public class Result
    {
        [JsonPropertyName("createdAt")]
        public long CreatedAt { get; set; }
        [JsonPropertyName("post_id")]
        public string PostID { get; set; } = "";
        [JsonPropertyName("class")]
        public string ClassId { get; set; } = "";

        [JsonPropertyName("subject")]
        public string Subject { get; set; } = "";
        [JsonPropertyName("desc")]
        public string Description { get; set; } = "";
        [JsonPropertyName("content")]
        public Content Content { get; set; } = new();

    }
    public class Content
    {
        [JsonPropertyName("isSimple")]
        public bool IsSimple { get; set; }
        [JsonPropertyName("htmlText")]
        public string HTMLText { get; set; } = "";
        [JsonPropertyName("imgSrcList")]
        public List<string> Images { get; set; } = new();
    }
}
