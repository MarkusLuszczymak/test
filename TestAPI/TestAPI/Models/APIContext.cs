using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Data;
using static System.Net.Mime.MediaTypeNames;
using WebApi.Models;

namespace TestAPI.Models
{
    public class APIContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Entries> Entries { get; set; }


        private readonly IConfiguration Configuration;

        public APIContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sqlite database
            options.UseNpgsql("Host=localhost;Username=postgres;Password=avsrulez;Database=portal");
        }
    }
}
