using System.Collections.Generic;

namespace TvMazeScraper.services.models
{
    public class Show
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Person> Cast { get; set; }
    }
}