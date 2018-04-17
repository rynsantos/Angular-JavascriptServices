using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace angular_aspnetcore.Controllers
{
    [Route("api/[controller]")]
    public class HeroesController : Controller
    {
        private List<Hero> Heroes = new List<Hero>() {
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

        };


        [HttpGet("[action]")]
        public IEnumerable<Hero> TopHeroes()
        {
            var rnd = new Random();
            return Enumerable.Range(1, 4).Select(index => Heroes[rnd.Next(Heroes.Count)]);
        }
    }

    public class Hero {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
