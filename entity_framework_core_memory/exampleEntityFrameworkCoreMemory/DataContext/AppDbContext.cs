using exampleEntityFrameworkCoreMemory.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace exampleEntityFrameworkCoreMemory.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        {
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
    }
}