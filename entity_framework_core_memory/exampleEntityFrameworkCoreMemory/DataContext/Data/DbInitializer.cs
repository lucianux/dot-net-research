using exampleEntityFrameworkCoreMemory.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System;

namespace exampleEntityFrameworkCoreMemory.DataContext.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var _context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                // Adding Artists to DB
                if (_context.Artists.Any())
                {
                    return;
                }

                _context.Artists.AddRange(
                    new Artist { Name = "Luis Miguel" },
                    new Artist { Name = "Ricardo Arjona" },
                    new Artist { Name = "Kalimba" }
                 );

                _context.SaveChanges();

                // Adding Albums to DB
                if (_context.Albums.Any())
                {
                    return;
                }

                _context.Albums.AddRange(
                    new Album
                    {
                        ArtistId = _context.Artists.FirstOrDefault(
                            a => a.Name.Equals("Kalimba")).Id,
                        Title = $"Mi Otro Yo",
                        Price = 200
                    },

                    new Album
                    {
                        ArtistId = _context.Artists.FirstOrDefault(
                            a => a.Name.Equals("Kalimba")).Id,
                        Title = $"Aerosoul",
                        Price = 275
                    },

                    new Album
                    {
                        ArtistId = _context.Artists.FirstOrDefault(
                            a => a.Name.Equals("Ricardo Arjona")).Id,
                        Title = $"Circo Soledad",
                        Price = 180
                    },

                    new Album
                    {
                        Id = _context.Artists.FirstOrDefault(
                            a => a.Name.Equals("Luis Miguel")).Id,
                        Title = $"Romance",
                        Price = 290
                    }
                );

                _context.SaveChanges();
            }
        }
    }
}