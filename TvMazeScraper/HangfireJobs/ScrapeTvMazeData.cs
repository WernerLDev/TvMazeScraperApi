using System;
using TvMazeScraper.ApiClients.TvMazeApi;
using TvMazeScraper.Database;
using TvMazeScraper.Repositories.interfaces;
using System.Linq;
using System.Threading.Tasks;
using TvMazeScraper.Database.Models;
using System.Collections.Generic;

namespace TvMazeScraper.HangfireJobs
{
  public class ScrapeTvMazeData : IScrapeTvMazeData
  {
    
    private TvMazeDbContext DbContext;
    private IShowsRepository ShowsRepository;
    private ICastRepository CastRepository;
    private IPersonRepository PersonRepository;
    private ITvMazeApi TvMazeApi;

    public ScrapeTvMazeData(TvMazeDbContext dbContext, IShowsRepository showsRepository, ITvMazeApi tvMazeApi, ICastRepository castRepository, IPersonRepository personRepository)
    {
      DbContext = dbContext;
      ShowsRepository = showsRepository;
      TvMazeApi = tvMazeApi;
      CastRepository = castRepository;
      PersonRepository = personRepository;
    }

    public virtual async Task ScrapeData()
    {
      Console.WriteLine("Started TvMazeScrape job");

      var latestShowId = ShowsRepository.GetLatestAddedShowId();
      int nextPage = 0;
      if(latestShowId > 0)
      {
        decimal pageNr = latestShowId / 250;
        nextPage = (int)Math.Floor(pageNr);
      }

      var shows = await TvMazeApi.GetShows(nextPage);

      Console.WriteLine("Loaded 250 shows");

      foreach(var show in shows) {
        var existingShow = DbContext.Shows.Where(s => s.ShowId.Equals(show.Id)).FirstOrDefault();
        if(existingShow != null)
        {
          continue;
        }
        
        var castResponse = await TvMazeApi.GetCastMembers((int)show.Id);

        Console.WriteLine("Received cast for show");

        var newShow = new Show() {
          ShowId = (int)show.Id,
          Name = show.Name
        };

        await ShowsRepository.AddShow(newShow);

        HashSet<long> AddedPersons = new HashSet<long>();

        foreach(var castMember in castResponse)
        {
          // Some shows contain dubplicates
          if(AddedPersons.Contains(castMember.Person.Id))
          {
            continue;
          }

          var person = PersonRepository.CreateOrGet(new Person() {
            PersonId = (int)castMember.Person.Id,
            Name =castMember.Person.Name,
            Birthday = castMember.Person.Birthday?.DateTime ?? new DateTime(1970,1,1)
          });

          var showPerson = new ShowPerson() {
            PersonId = person.PersonId,
            ShowId = newShow.ShowId
          };
          Console.WriteLine($"ShowId {newShow.ShowId}, PersonId {person.PersonId}");
          DbContext.ShowPersons.Add(showPerson);
          AddedPersons.Add(castMember.Person.Id);
        }
        DbContext.SaveChanges();

        Console.WriteLine($"Added show {newShow.Name}");

        System.Threading.Thread.Sleep(1000);

      }
    }
  }
}