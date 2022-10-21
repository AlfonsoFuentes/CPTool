



using CPTool.Application.Features.EHSItemFeatures.CreateEdit;

namespace CPTool.Application.Features.EHSItemFeatures.Mapping
{
    internal class EHSItemMapping : Profile
    {
        public EHSItemMapping()
        {
            CreateMap<EHSItem, EditEHSItem>();
           

            CreateMap<AddEHSItem, EHSItem>();
            CreateMap<EditEHSItem, EHSItem>();
            CreateMap<EditEHSItem, AddEHSItem>();
        }
    }
}
