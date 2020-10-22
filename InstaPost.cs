using Newtonsoft.Json;
using System;

namespace instagrab
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Post
    {
        [JsonProperty("id")]
        public string Id{get;set;}
        [JsonProperty("accessibility_caption")]
        public string accessibility_caption { get;set;}
        public string caption { get; set; }
        [JsonProperty("display_url")]
        public Uri display_url { get;set;}
        [JsonProperty("is_video")]
        public bool is_video { get; set; }

    }
}