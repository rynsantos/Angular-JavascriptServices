using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using angular_aspnetcore.Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace angular_aspnetcore.Controllers
{
    [Route("api/[controller]")]
    public class HeroesController : Controller
    {
        private readonly AppDbContext _db;
        public HeroesController(AppDbContext db) {
            this._db = db;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> TopHeroes()
        {
            return Ok(this._db.Heroes.Take(4));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(this._db.Heroes.Single(_=>_.Id == id));
        }
    }
}
