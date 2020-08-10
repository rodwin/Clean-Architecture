using AutoMapper;

namespace CA.Application.UnitTests
{
    public class MappingFixture
    {
        public MappingFixture()
        {
            Mapper = MapperFactory.Create();
        }

        public IMapper Mapper { get; set; }
    }
}
