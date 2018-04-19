using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace angular_aspnetcore.Domain
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Hero> Heroes { get; set; }
    }

    public static class DbContextExtension {
        public static void EnsureSeeded(this AppDbContext context) {

            context.Heroes.AddRange(new List<Hero>() {
                new Hero { Id = 1, Name = "Mr. Nice" },
                new Hero { Id = 2, Name = "Narco" },
                new Hero { Id = 3, Name = "Bombasto" },
                new Hero { Id = 4, Name = "Celeritas" },
                new Hero { Id = 5, Name = "Magneta" },
                new Hero { Id = 6, Name = "RubberMan" },
                new Hero { Id = 7, Name = "Dynama" },
                new Hero { Id = 8, Name = "Dr IQ" },
                new Hero { Id = 9, Name = "Magma" },
                new Hero { Id = 10, Name = "Tornado" }
            });

            context.SaveChanges();
        }
    }
}
