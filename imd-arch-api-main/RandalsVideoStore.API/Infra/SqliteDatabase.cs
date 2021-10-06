using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RandalsVideoStore.API.Domain;
using RandalsVideoStore.API.Ports;

namespace RandalsVideoStore.API.Infra
{
    public class SqliteDatabase : IDatabase
    {
        private VideoStoreContext _context;

        public SqliteDatabase(VideoStoreContext context)
        {
            _context = context;
        }
        public async Task DeleteMovie(Guid parsedId)
        {
            var movie = await _context.Movies.FindAsync(parsedId);
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
        }

        public async Task<ReadOnlyCollection<Movie>> GetAllMovies(string titleStartsWith)
        {

            var movies = await _context.Movies.Where(x => EF.Functions.Like(x.Title, $"{titleStartsWith}%")).ToArrayAsync();
            return Array.AsReadOnly(movies);
        }

        public async Task<Movie> GetMovieById(Guid parsedId)
        {
            return await _context.Movies.FindAsync(parsedId);
        }

        public async Task<Movie> PersistMovie(Movie movie)
        {
            if (movie.Id == null)
            {
                await _context.Movies.AddAsync(movie);
            }
            else
            {
                _context.Movies.Update(movie);
            }
            await _context.SaveChangesAsync();
            return movie;
        }
    }
}