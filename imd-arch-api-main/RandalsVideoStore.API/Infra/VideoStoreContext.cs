using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RandalsVideoStore.API.Domain;

namespace RandalsVideoStore.API.Infra
{
    public class VideoStoreContext : DbContext
    {
        public VideoStoreContext(DbContextOptions<VideoStoreContext> ctx) : base(ctx)
        {

        }

        public DbSet<Movie> Movies { get; set; }
    }
}