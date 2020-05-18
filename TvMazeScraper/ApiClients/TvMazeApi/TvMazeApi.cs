namespace TvMazeScraper.ApiClients.TvMazeApi
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
  using System.Net.Http;
  using System.Threading.Tasks;
  using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
  using TvMazeScraper.ApiClients.TvMazeApi.Models;

  public class TvMazeApi : ITvMazeApi
  {

    private HttpClient client;

    public TvMazeApi()
    {
      this.client = new HttpClient();
      client.BaseAddress = new Uri("http://api.tvmaze.com/");
    }

    public async Task<IList<TvMazeCast>> GetCastMembers(int showId)
    {
      var response = await this.client.GetAsync($"shows/{showId}/cast");
      if(response.IsSuccessStatusCode)
      {
        return JsonConvert.DeserializeObject<IList<TvMazeCast>>(await response.Content.ReadAsStringAsync());
      }
      throw new Exception($"Failed fetching cast for show {showId}");
    }

    public async Task<IList<TvMazeShow>> GetShows(int page)
    {
      var response = await this.client.GetAsync($"shows?page={page}");
      if(response.IsSuccessStatusCode)
      {
        return JsonConvert.DeserializeObject<IList<TvMazeShow>>(await response.Content.ReadAsStringAsync());
      }

      throw new Exception("Failed fetching shows");
    }
  }
}
