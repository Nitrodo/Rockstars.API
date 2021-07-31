using AutoMapper;
using Rockstars.Application.Mappers;
using Xunit;

namespace Rockstars.Application.UnitTests
{
    public class MapperTests
    {
        [Fact]
        public void AutoMapper_Configuration_IsValid()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
            config.AssertConfigurationIsValid();
        }
    }
}
