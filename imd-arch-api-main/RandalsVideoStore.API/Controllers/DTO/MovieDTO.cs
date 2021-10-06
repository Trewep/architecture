using System;
using System.Linq;
using RandalsVideoStore.API.Domain;

namespace RandalsVideoStore.API.Controllers
{
    // DTO stands for Data Transfer Object; these are dumb classes that should only be used
    // for transferring data between layers of the application.
    public class CreateMovie
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public Genre Genres { get; set; }

        public Movie ToMovie() => new Movie { Title = this.Title, Year = this.Year, Genres = this.Genres };
    }

    public class ViewMovie
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string FormattedYear { get; set; }
        public Genre Genres { get; set; }

        public static ViewMovie FromModel(Movie movie) => new ViewMovie
        {
            Id = movie.Id.ToString(),
            Title = movie.Title,
            Year = movie.Year,
            Genres = movie.Genres,
            FormattedYear = FormatYear(movie.Year),
        };

        private static string FormatYear(int year)
        {
            var yearAsString = year.ToString();
            return yearAsString.Length == 4 ? "'" + yearAsString.Substring(2, 2) : yearAsString;
        }
    }
}