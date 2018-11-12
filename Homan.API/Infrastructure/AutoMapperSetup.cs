using AutoMapper;
using Homan.API.Models;
using Homan.BLL.Models;

namespace Homan.API.Infrastructure
{
    public class AutoMapperSetup : Profile
    {
        public AutoMapperSetup()
        {
            CreateMap<LoginRequestWebModel, LoginRequestModel>();
            CreateMap<RegistrationRequestWebModel, RegistrationRequestModel>();
            CreateMap<HomeSpaceModel, HomeSpaceWebModel>();
            CreateMap<LoginResponseModel, LoginResponseWebModel>();
        }
    }
}