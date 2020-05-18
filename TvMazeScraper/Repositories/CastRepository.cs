using TvMazeScraper.Database;
using TvMazeScraper.Database.Models;
using TvMazeScraper.Repositories.interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace TvMazeScraper.Repositories
{
    public class CastRepository : ICastRepository
    {
        public CastRepository(TvMazeDbContext _dbContext)
    {
      DbContext = _dbContext;
    }
    
    private TvMazeDbContext DbContext { get; }

    public async Task CreateCastMember(Cast cast)
    {
        DbContext.Add(cast);
        await DbContext.SaveChangesAsync();
    }
  }
}