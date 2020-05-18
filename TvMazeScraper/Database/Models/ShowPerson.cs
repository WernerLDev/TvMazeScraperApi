namespace TvMazeScraper.Database.Models
{
    public class ShowPerson
    {
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
        public int ShowId { get; set; }
        public virtual Show Show { get; set; }
    }
}