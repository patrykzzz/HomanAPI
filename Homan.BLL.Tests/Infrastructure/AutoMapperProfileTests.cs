using AutoMapper;
using Xunit;

namespace Homan.BLL.Tests.Infrastructure
{
    [Collection("AutoMapper")]
    public class AutoMapperProfileTests
    {
        [Fact]
        public void AutoMapperProfile_ShouldHaveCorrectlyDefinedMappings()
        {
            Mapper.AssertConfigurationIsValid();
        }
    }
}