using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Dynamic;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace instagrab
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        
        static async Task Main(string[] args)
        {
            
            Console.WriteLine("Hello World!");
            TotalUserInfo user = await GatherUser("gusevski_");
            TotalUserInfo userW = await GatherUser("wylsacom");
            Console.ReadKey();
        }

        private static async Task<TotalUserInfo> GatherUser(string username)
        {
            try
            {
                var response = await client.GetAsync($"https://www.instagram.com/{username}/?__a=1");
                dynamic temp = JObject.Parse(await response.Content.ReadAsStringAsync());
                
                User user = JsonConvert.DeserializeObject<User>(Convert.ToString(temp.graphql.user));
                user.followers = temp.graphql.user.edge_followed_by.count;

                List<Post> posts = new List<Post>();
                foreach (dynamic post in temp.graphql.user.edge_owner_to_timeline_media.edges)
                {
                    Post instaPost = JsonConvert.DeserializeObject<Post>(Convert.ToString(post.node));

                    #region description
                    foreach (dynamic text in post.node.edge_media_to_caption.edges)
                    {
                        instaPost.caption = text.node.text;
                    }
                    #endregion
                    posts.Add(instaPost);
               }
               return new TotalUserInfo() { user = user, posts = posts };
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }
    }
}
