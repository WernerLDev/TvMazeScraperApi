using System;
using System.Text.Json.Serialization;
using TvMazeScraper.Converters;

namespace TvMazeScraper.services.models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonConverter(typeof(JsonDateConverter))]
        public DateTime Birthday { get; set; } 
    }
}