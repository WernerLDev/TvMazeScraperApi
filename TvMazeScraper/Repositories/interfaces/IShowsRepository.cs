using System.Collections.Generic;
using System.Threading.Tasks;
using TvMazeScraper.Database.Models;

namespace TvMazeScraper.Repositories.interfaces
{
  public interface IShowsRepository
  {
    IList<Show> RetrieveShows(int Page, int PerPage);
    int GetLatestAddedShowId();
    Task AddShow(Show show);
  }
}