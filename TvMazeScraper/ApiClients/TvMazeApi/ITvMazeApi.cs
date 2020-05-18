using System.Collections.Generic;
using System.Threading.Tasks;
using TvMazeScraper.ApiClients.TvMazeApi.Models;

namespace TvMazeScraper.ApiClients.TvMazeApi
{
    public interface ITvMazeApi
    {
        Task<IList<TvMazeShow>> GetShows(int page);
        Task<IList<TvMazeCast>> GetCastMembers(int showId);
    }
}
