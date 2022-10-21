



using CPTool.Application.Features.ElectricalItemFeatures.CreateEdit;

namespace CPTool.Application.Features.ElectricalItemFeatures.Mapping
{
    internal class ElectricalItemMapping : Profile
    {
        public ElectricalItemMapping()
        {
            CreateMap<ElectricalItem, EditElectricalItem>();

            CreateMap<EditElectricalItem, ElectricalItem>();
            CreateMap<AddElectricalItem, ElectricalItem>();
            CreateMap<EditElectricalItem, AddElectricalItem>();
        }
    }
}
