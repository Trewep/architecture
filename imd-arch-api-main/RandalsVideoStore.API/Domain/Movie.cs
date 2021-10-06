using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RandalsVideoStore.API.Domain
{
    // this is a domain model. It contains the full representation of an entity within our domain.
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? Id { get; set; }
        public int Year { get; set; }
        public string Title { get; set; }

        [Column(TypeName = "int")]
        public Genre Genres { get; set; }
    }
}
