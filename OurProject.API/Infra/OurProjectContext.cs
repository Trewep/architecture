//Microsoft
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

//OurProject
using OurProject.API.Domains;
using OurProject.API.Ports;
using OurProject.API.Controllers;

//System
using System;

//Namespace
namespace OurProject.API.Infra
{
    public class OurProjectContext : DbContext
    {
        public OurProjectContext(DbContextOptions<OurProjectContext> ctx) : base(ctx) { }
        public DbSet<User> User { get; set; }
        public DbSet<Event> Events { get; set; }
    }
}