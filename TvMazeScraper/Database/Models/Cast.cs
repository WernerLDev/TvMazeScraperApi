namespace TvMazeScraper.Database.Models
{
    public class Cast
    {
        public int ShowId { get; set; }
        public int PersonId { get; set; }
        public virtual Show Show { get; set; }
        public virtual Person Person { get; set; }
    }
}