using System;
using AutoMapper;
using Homan.API.Models;
using Homan.BLL.Models;

namespace Homan.API.Infrastructure
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<LoginRequestWebModel, LoginRequestModel>();
            CreateMap<RegistrationRequestWebModel, RegistrationRequestModel>();
            CreateMap<HomeSpaceModel, HomeSpaceWebModel>();
            CreateMap<HomeSpaceWebModel, HomeSpaceModel>()
                .ForMember(x => x.Id, o => o.Ignore());
            CreateMap<LoginResponseModel, LoginResponseWebModel>();
            CreateMap<HomeSpaceInvitationWebModel, HomeSpaceInvitationModel>();

            CreateMap<HomeSpaceItemCreateWebModel, HomeSpaceItemModel>()
                .ForMember(x => x.User, o => o.Ignore())
                .ForMember(x => x.IsCompleted, o => o.MapFrom(s => false))
                .ForMember(x => x.Id, o => o.Ignore());

            CreateMap<HomeSpaceItemModel, HomeSpaceItemWebModel>()
                .ForMember(x => x.UserName, o => o.Condition(s => s.User != null))
                .ForMember(x => x.UserName, o => o.MapFrom(s => $"{s.User.FirstName} {s.User.LastName}"));

            CreateMap<HomeSpaceItemWebModel, HomeSpaceItemModel>();
        }
    }
}