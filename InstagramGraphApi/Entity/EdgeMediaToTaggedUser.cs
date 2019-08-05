/*
 * Developer: Milad Raeisi [ miladsoft@yahoo.com ] [ My Telegram Account: https://t.me/miladsoft ]
 * 
 * Github source: https://github.com/miladsoft/InstagramGraphApi
 * Nuget package: https://www.nuget.org/packages/Miladsoft.InstagramGraphApi/
 * 
 */
using System.Collections.Generic;
using Newtonsoft.Json;

namespace InstagramGraphApi.Entity
{
    public class EdgeMediaToTaggedUser
    {
        [JsonProperty("edges")]
        public List<EdgeMediaToTaggedUserEdges> Edges { get; set; }
    }

    public class EdgeMediaToTaggedUserEdges
    {
        [JsonProperty("node")]
        public EdgeMediaToTaggedUserNode Node { get; set; }
    }

    public class EdgeMediaToTaggedUserNode
    {
        [JsonProperty("user")]
        public EdgeMediaToTaggedUserUser User { get; set; }

        [JsonProperty("x")]
        public double X { get; set; }

        [JsonProperty("y")]
        public double Y { get; set; }
    }

    public class EdgeMediaToTaggedUserUser
    {
        [JsonProperty("full_name")]
        public string Fullname { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("is_verified")]
        public bool IsVerified { get; set; }

        [JsonProperty("profile_pic_url")]
        public string ProfilePicUrl { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }
    }

    

    
}
