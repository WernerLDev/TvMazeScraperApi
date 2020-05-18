using System.Threading.Tasks;
using TvMazeScraper.Database.Models;

namespace TvMazeScraper.Repositories.interfaces
{
    public interface ICastRepository
    {
         Task CreateCastMember(Cast cast);
    }
}