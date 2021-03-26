using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.DTOs
{
    public class BookDTO
    {

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}