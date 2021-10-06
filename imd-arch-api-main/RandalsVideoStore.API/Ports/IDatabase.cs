using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using RandalsVideoStore.API.Domain;

namespace RandalsVideoStore.API.Ports
{
    public interface IDatabase
    {
        Task<ReadOnlyCollection<Movie>> GetAllMovies(string titleStartsWith);
        Task<Movie> GetMovieById(Guid id);
        Task<Movie> PersistMovie(Movie movie);
        Task DeleteMovie(Guid parsedId);
    }
}