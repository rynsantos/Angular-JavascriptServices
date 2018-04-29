using angular_aspnetcore.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace angular_aspnetcore.Controllers.Heroes
{
    public class Detail
    {
        public class ViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }

        }

        public class Query: IRequest<ViewModel>
        {
            public int Id { get; set; } 
        }

        public class Handler: AsyncRequestHandler<Query, ViewModel>
        {
            private readonly AppDbContext _db;

            public Handler(AppDbContext db)
            {
                this._db = db;
            }
            

            protected override Task<ViewModel> HandleCore(Query request)
            {
                var hero = this._db
                    .Heroes
                    .FirstOrDefault(_ => _.Id == request.Id);

                var x = Mapper.Map<Hero, ViewModel>(hero);
                return Task.FromResult<ViewModel>(Mapper.Map<Hero,ViewModel>(hero));                
            }
        }

        public class QueryTopHeroes : IRequest<List<ViewModel>>
        {
            public int Id { get; set; }
        }

        public class HandlerTopHeroes : AsyncRequestHandler<QueryTopHeroes, List<ViewModel>>
        {
            private readonly AppDbContext _db;

            public HandlerTopHeroes(AppDbContext db)
            {
                this._db = db;
            }


            protected override Task<List<ViewModel>> HandleCore(QueryTopHeroes request)
            {
                var heroes = this._db
                    .Heroes
                    .Take(4)
                    .ToList();
                                
                return Task.FromResult<List<ViewModel>>(Mapper.Map<List<Hero>, List<ViewModel>>(heroes));
            }
        }
    }
}
