/*
 * Developer: Milad Raeisi [ miladsoft@yahoo.com ] [ My Telegram Account: https://t.me/miladsoft ]
 * 
 * Github source: https://github.com/miladsoft/InstagramGraphApi
 * Nuget package: https://www.nuget.org/packages/InstagramGraphApi
 * 
 */
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramGraphApi.Entity
{
    public class EdgeMutualFollowedBy
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("edges")]
        public List<EdgeMutualFollowedByEdges> Edges { get; set; }
    }

    public class EdgeMutualFollowedByEdges
    {
        [JsonProperty("node")]
        public EdgeMutualFollowedByNode Node { get; set; }
    }

    public class EdgeMutualFollowedByNode
    {
        [JsonProperty("username")]
        public string Username { get; set; }
    }
}
