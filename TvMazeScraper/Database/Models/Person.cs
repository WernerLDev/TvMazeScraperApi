using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TvMazeScraper.Converters;

namespace TvMazeScraper.Database.Models
{
    public class Person
    {
    public int PersonId { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; } 

        public virtual ICollection<ShowPerson> ShowPersons { get; set; }
    }
}