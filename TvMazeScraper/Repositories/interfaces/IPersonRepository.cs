using TvMazeScraper.Database.Models;

namespace TvMazeScraper.Repositories.interfaces
{
    public interface IPersonRepository
    {
        Person CreateOrGet(Person person);
    }
}