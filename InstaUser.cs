using Newtonsoft.Json;
using System;

namespace instagrab
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class User
    {
        public string username { get;set;}
        public string profile_pic_url_hd { get; set; }
        public string biography { get; set; }
        public string full_name { get; set; }
        public int followers { get; set; }
        public string external_url { get; set; }
    }
}