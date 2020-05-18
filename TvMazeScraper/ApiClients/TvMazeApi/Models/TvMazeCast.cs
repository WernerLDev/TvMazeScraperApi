namespace TvMazeScraper.ApiClients.TvMazeApi.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class TvMazeCast
    {
        [JsonProperty("person")]
        public Person Person { get; set; }

        [JsonProperty("character")]
        public Character Character { get; set; }

        [JsonProperty("self")]
        public bool Self { get; set; }

        [JsonProperty("voice")]
        public bool Voice { get; set; }
    }

    public partial class Character
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("image")]
        public Image Image { get; set; }

        [JsonProperty("_links")]
        public Links Links { get; set; }
    }

    
    public partial class Self
    {
        [JsonProperty("href")]
        public Uri Href { get; set; }
    }

    public partial class Person
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("country")]
        public Country Country { get; set; }

        [JsonProperty("birthday")]
        public DateTimeOffset? Birthday { get; set; }

        [JsonProperty("deathday")]
        public object Deathday { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("image")]
        public Image Image { get; set; }

        [JsonProperty("_links")]
        public Links Links { get; set; }
    }
}