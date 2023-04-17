using AutoMapper;
using Gradebook.Application.Configuration.Mappings;

namespace Gradebook.UnitTests;

internal class MapperHelper
{
    public static IMapper CreateMapper(Profile profile)
    {
        var mappingConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(profile);
        });

        return mappingConfig.CreateMapper();
    }

    public static IMapper CreateMapper(IEnumerable<Profile> profiles)
    {
        var mappingConfig = new MapperConfiguration(mc =>
        {
            foreach (var profile in profiles)
            {
                mc.AddProfile(profile);
            }
        });

        return mappingConfig.CreateMapper();
    }
}
