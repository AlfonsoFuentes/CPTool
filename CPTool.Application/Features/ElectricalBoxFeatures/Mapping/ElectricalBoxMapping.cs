



using CPTool.Application.Features.ElectricalBoxsFeatures.CreateEdit;


namespace CPTool.Application.Features.ElectricalBoxsFeatures.Mapping
{
    internal class ElectricalBoxMapping : Profile
    {
        public ElectricalBoxMapping()
        {
            CreateMap<ElectricalBox, EditElectricalBox>();
            CreateMap<AddElectricalBox, ElectricalBox>();
            CreateMap<EditElectricalBox, ElectricalBox>();
            CreateMap<EditElectricalBox, AddElectricalBox>();
        }
    }
}
