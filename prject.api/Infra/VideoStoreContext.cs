using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using prject.API.Domain;

namespace prject.API.Infra
{
    public class VideoStoreContext : DbContext
    {
        public VideoStoreContext(DbContextOptions<VideoStoreContext> ctx) : base(ctx)
        {

        }

        public DbSet<Movie> Movies { get; set; }
    }
}