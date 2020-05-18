using System.Collections.Generic;

namespace TvMazeScraper.Database.Models
{
    public class Show
    {

        public int ShowId { get; set; }
        public string Name { get; set; }
        public virtual IList<ShowPerson> ShowPersons { get; set; }
    }
}
