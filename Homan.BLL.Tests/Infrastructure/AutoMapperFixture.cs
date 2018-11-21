using AutoMapper;
using Homan.BLL.Infrastructure;

namespace Homan.BLL.Tests.Infrastructure
{
    public class AutoMapperFixture
    {
        public AutoMapperFixture()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
        }
    }
}