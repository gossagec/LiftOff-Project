using LiftOff_Project.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LiftOff_Project.Data
{
    public class ApplictaionDbContext : IdentityDbContext
    {
        public DbSet<Song> Songs { get; set; }
        public ApplictaionDbContext(DbContextOptions<ApplictaionDbContext> options) : base(options)
        {
        }
    }
}
