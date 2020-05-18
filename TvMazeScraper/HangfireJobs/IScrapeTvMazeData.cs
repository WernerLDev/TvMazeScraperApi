using System.Threading.Tasks;

namespace TvMazeScraper.HangfireJobs
{
    public interface IScrapeTvMazeData
    {
         Task ScrapeData();
    }
}