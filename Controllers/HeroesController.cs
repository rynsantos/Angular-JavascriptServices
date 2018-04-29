using System.Linq;
using System.Threading.Tasks;
using angular_aspnetcore.Controllers.Heroes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace angular_aspnetcore.Controllers
{
    [Route("api/[controller]")]
    public class HeroesController : Controller
    {
        private readonly IMediator _mediator;
        public HeroesController(IMediator mediator) {
            this._mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> TopHeroes()
        {
            return Ok(await _mediator.Send(new Detail.QueryTopHeroes()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            
            return Ok(await _mediator.Send(new Detail.Query { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Create.Command command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
