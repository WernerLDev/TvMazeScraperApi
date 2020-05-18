using System.Linq;
using Microsoft.EntityFrameworkCore;
using TvMazeScraper.Database;
using TvMazeScraper.Database.Models;
using TvMazeScraper.Repositories.interfaces;

namespace TvMazeScraper.Repositories
{
  public class PersonRepository : IPersonRepository
  {
    private TvMazeDbContext DbContext;
    public PersonRepository(TvMazeDbContext dbContext)
    {
      DbContext = dbContext;
    }

    public Person CreateOrGet(Person newPerson)
    {
      var person = DbContext.Persons.AsNoTracking().Where(x => x.PersonId.Equals(newPerson.PersonId)).FirstOrDefault();
      if(person == null)
      {
        person = newPerson;
        DbContext.Persons.Add(newPerson);
        DbContext.SaveChanges();
      }
      return person;
    }
  }
}