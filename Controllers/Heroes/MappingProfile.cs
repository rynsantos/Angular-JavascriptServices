using angular_aspnetcore.Domain;
using AutoMapper;
using System.Collections.Generic;
using static angular_aspnetcore.Controllers.Heroes.Detail;

namespace angular_aspnetcore.Controllers.Heroes
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Create.Command, Hero>(MemberList.None);

            CreateMap<Hero,ViewModel>(MemberList.None);
        }
    }
}
