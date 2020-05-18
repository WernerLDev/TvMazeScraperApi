using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TvMazeScraper.Database;
using TvMazeScraper.Database.Models;
using TvMazeScraper.Repositories.interfaces;

namespace TvMazeScraper.Repositories
{
  public class ShowsRepository : IShowsRepository
  {
    public ShowsRepository(TvMazeDbContext _dbContext)
    {
      DbContext = _dbContext;
    }
    
    private TvMazeDbContext DbContext { get; }

    public async Task AddShow(Show show)
    {
      DbContext.Shows.Add(show);
      await DbContext.SaveChangesAsync();
    }

    public int GetLatestAddedShowId()
    {
      var latestShow = DbContext.Shows.OrderByDescending(x => x.ShowId).FirstOrDefault();
      return latestShow?.ShowId ?? 0;
    }

    public IList<Show> RetrieveShows(int Page, int PerPage)
    {
      return DbContext.Shows
        .Include(x => x.ShowPersons)
        .ThenInclude(x => x.Person)
        .OrderBy(x => x.ShowId)
        .Skip(Page * PerPage)
        .Take(PerPage)
        .Select(show => new Show() {
          ShowId = show.ShowId,
          Name = show.Name,
          ShowPersons = show.ShowPersons
            .OrderByDescending(person => person.Person.Birthday)
            .ToList()
        })
        .ToList();
    }
  }
}