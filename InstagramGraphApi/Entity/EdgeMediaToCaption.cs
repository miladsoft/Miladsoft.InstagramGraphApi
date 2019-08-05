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
    public class EdgeMediaToCaption
    {
        [JsonProperty("edges")]
        public List<EdgeMediaToCaptionEdges> Edges { get; set; }
    }

    public class EdgeMediaToCaptionEdges
    {
        [JsonProperty("node")]
        public EdgeMediaToCaptionNode Node { get; set; }
    }

    public class EdgeMediaToCaptionNode
    {
        [JsonProperty("text")]
        public string Text { get; set; }
    }    
}
