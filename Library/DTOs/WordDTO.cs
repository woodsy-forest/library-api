using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.DTOs
{
    public class WordDTO
    {

        [JsonProperty(PropertyName = "word")]
        public string Word { get; set; }

        [JsonProperty(PropertyName = "count")]
        public int Count { get; set; }
    }
}