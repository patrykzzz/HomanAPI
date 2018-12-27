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
        }
    }
}