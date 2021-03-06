namespace TvMazeScraper.ApiClients.TvMazeApi.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class TvMazeShow
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("genres")]
        public string[] Genres { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("runtime")]
        public long Runtime { get; set; }

        [JsonProperty("premiered")]
        public DateTimeOffset Premiered { get; set; }

        [JsonProperty("officialSite")]
        public Uri OfficialSite { get; set; }

        [JsonProperty("schedule")]
        public Schedule Schedule { get; set; }

        [JsonProperty("rating")]
        public Rating Rating { get; set; }

        [JsonProperty("weight")]
        public long Weight { get; set; }

        [JsonProperty("network")]
        public Network Network { get; set; }

        [JsonProperty("webChannel")]
        public Network WebChannel { get; set; }

        [JsonProperty("externals")]
        public Externals Externals { get; set; }

        [JsonProperty("image")]
        public Image Image { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("updated")]
        public long Updated { get; set; }

        [JsonProperty("_links")]
        public Links Links { get; set; }
    }

    public partial class Externals
    {
        [JsonProperty("tvrage")]
        public long Tvrage { get; set; }

        [JsonProperty("thetvdb")]
        public long? Thetvdb { get; set; }

        [JsonProperty("imdb")]
        public string Imdb { get; set; }
    }

    public partial class Image
    {
        [JsonProperty("medium")]
        public Uri Medium { get; set; }

        [JsonProperty("original")]
        public Uri Original { get; set; }
    }

    public partial class Links
    {
        [JsonProperty("self")]
        public Previousepisode Self { get; set; }

        [JsonProperty("previousepisode")]
        public Previousepisode Previousepisode { get; set; }
    }

    public partial class Previousepisode
    {
        [JsonProperty("href")]
        public Uri Href { get; set; }
    }

    public partial class Network
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("country")]
        public Country Country { get; set; }
    }

    public partial class Country
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }
    }

    public partial class Rating
    {
        [JsonProperty("average")]
        public object Average { get; set; }
    }

    public partial class Schedule
    {
        [JsonProperty("time")]
        public string Time { get; set; }

        [JsonProperty("days")]
        public string[] Days { get; set; }
    }
}