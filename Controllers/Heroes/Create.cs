using angular_aspnetcore.Domain;
using AutoMapper;
using MediatR;
using static angular_aspnetcore.Controllers.Heroes.Create;

namespace angular_aspnetcore.Controllers.Heroes
{
    public class Create
    {
        public class Command : IRequest
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class Handler : RequestHandler<Command>
        {
            private readonly AppDbContext _db;

            public Handler(AppDbContext db)
            {
                this._db = db;
            }

            protected override void HandleCore(Command message)
            {
                var hero = Mapper.Map<Command, Hero>(message);

                _db.Heroes.Add(hero);
            }
        }
    }
}
