using AutoMapper;
using Homan.BLL.Models;
using Homan.DAL.Entities;

namespace Homan.BLL.Infrastructure
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<HomeSpace, HomeSpaceModel>();
            CreateMap<HomeSpaceModel, HomeSpace>()
                .ForMember(x => x.OwnerId, o => o.Ignore())
                .ForMember(x => x.Owner, o => o.Ignore())
                .ForMember(x => x.HomeSpaceUsers, o => o.Ignore())
                .ForMember(x => x.HomeSpaceItems, o => o.Ignore());
        }
    }
}