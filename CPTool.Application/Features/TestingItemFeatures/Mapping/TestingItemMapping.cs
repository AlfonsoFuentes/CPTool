



using CPTool.Application.Features.TestingItemFeatures.CreateEdit;

namespace CPTool.Application.Features.TestingItemFeatures.Mapping
{
    internal class TestingItemMapping : Profile
    {
        public TestingItemMapping()
        {
            CreateMap<TestingItem, EditTestingItem>();

            CreateMap<EditTestingItem, TestingItem>();
            CreateMap<AddTestingItem, TestingItem>();
        }
    }
}
