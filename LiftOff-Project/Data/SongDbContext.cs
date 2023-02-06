using LiftOff_Project.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LiftOff_Project.Data
{
    public class SongDbContext : IdentityDbContext
    {
        public DbSet<Song> Songs { get; set; }
        public SongDbContext(DbContextOptions<SongDbContext> options) : base(options)
        {
        }
    }
}
