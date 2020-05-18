using System.Collections.Generic;
using TvMazeScraper.services.models;

namespace TvMazeScraper.services
{
    public interface IShowService
    {
         IList<Show> GetShows(int page, int perPage);
    }
}