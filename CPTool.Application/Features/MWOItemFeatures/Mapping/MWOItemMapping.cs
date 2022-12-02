



using CPTool.Application.Features.MWOItemFeatures.CreateEdit;

namespace CPTool.Application.Features.MWOItemFeatures.Mapping
{
    internal class MWOItemMapping : Profile
    {
        public MWOItemMapping()
        {
            CreateMap<MWOItem, EditMWOItem>();
            CreateMap<EditMWOItem, MWOItem>();
            CreateMap<AddMWOItem, MWOItem>();
            CreateMap<EditMWOItem, AddMWOItem>();

          
        }
    }
    
}
