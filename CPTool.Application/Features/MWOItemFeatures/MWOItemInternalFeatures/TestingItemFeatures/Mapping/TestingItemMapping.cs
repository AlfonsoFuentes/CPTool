using CPTool.Application.Features.MWOItemFeatures.MWOItemInternalFeatures.TestingItemFeatures.CreateEdit;

namespace CPTool.Application.Features.MWOItemFeatures.MWOItemInternalFeatures.TestingItemFeatures.Mapping
{
    internal class TestingItemMapping : Profile
    {
        public TestingItemMapping()
        {
            CreateMap<TestingItem, AddEditTestingItemCommand>()
                .ForMember(dest => dest.MWOItemsCommand, act => { act.PreCondition(src => src.MWOItems != null); act.MapFrom(src => src.MWOItems); });
              


            CreateMap<AddEditTestingItemCommand, TestingItem>();
        }
    }

}
