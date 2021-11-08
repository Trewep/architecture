using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OurProject.API.Models;

namespace OurProject.API.Ports
{
    public class EventOrgContext : DbContext
    {
        public EventOrgContext(DbContextOptions<EventOrgContext> ctx) : base(ctx)
        {

        }
        public DbSet<User> users { get; set; }
        public DbSet<Event> events { get; set; }
    }
}