using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using prject.API.Domain;

namespace prject.API.Ports
{
    public interface IDatabase
    {
        Task<ReadOnlyCollection<Movie>> GetAllMovies(string titleStartsWith);
        Task<Movie> GetMovieById(Guid id);
        Task<Movie> PersistMovie(Movie movie);
        Task DeleteMovie(Guid parsedId);
    }
}