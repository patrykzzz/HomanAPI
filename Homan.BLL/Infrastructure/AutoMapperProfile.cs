using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Homan.BLL.Models;
using Homan.DAL.Entities;

namespace Homan.BLL.Infrastructure
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<HomeSpace, HomeSpaceModel>()
                .ForMember(x => x.HomeSpaceUsers, o => o.MapFrom(s => s.HomeSpaceUsers.Select(y => y.User)));

            CreateMap<User, UserModel>();
            CreateMap<HomeSpaceItem, HomeSpaceItemModel>();

            CreateMap<HomeSpaceItemModel, HomeSpaceItem>()
                .ForMember(x => x.CreatedOn, o => o.Ignore())
                .ForMember(x => x.Name, o => o.Ignore())
                .ForMember(x => x.HomeSpace, o => o.Ignore());

            CreateMap<HomeSpaceModel, HomeSpace>()
                .ForMember(x => x.OwnerId, o => o.Ignore())
                .ForMember(x => x.Owner, o => o.Ignore())
                .ForMember(x => x.HomeSpaceUsers, o => o.MapFrom(s => new List<UserInHomeSpace>()))
                .ForMember(x => x.HomeSpaceItems, o => o.MapFrom(s => new List<HomeSpaceItem>()));
        }
    }
}