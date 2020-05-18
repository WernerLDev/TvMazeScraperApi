using System;
using System.Collections.Generic;
using System.Linq;
using TvMazeScraper.Repositories.interfaces;
using TvMazeScraper.services.models;

namespace TvMazeScraper.services
{
  public class ShowService : IShowService
  {
    
    private IShowsRepository ShowsRepository;

    public ShowService(IShowsRepository showsRepository)
    {
      ShowsRepository = showsRepository;
    }

    public IList<Show> GetShows(int page, int perPage)
    {
      return ShowsRepository.RetrieveShows(page, perPage).Select(show => new Show() {
        Id = show.ShowId,
        Name = show.Name,
        Cast = show.ShowPersons.Select(person => new Person() {
          Id = person.PersonId,
          Name = person.Person.Name,
          Birthday = person.Person.Birthday
        })
        .ToList()
      })
      .ToList();
    }
  }
}
