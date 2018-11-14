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
        }
    }
}