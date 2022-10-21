



using CPTool.Application.Features.GasketsFeatures.CreateEdit;


namespace CPTool.Application.Features.GasketsFeatures.Mapping
{
    internal class GasketMapping : Profile
    {
        public GasketMapping()
        {
            CreateMap<Gasket, EditGasket>();
            CreateMap<AddGasket, Gasket>();
            CreateMap<EditGasket, Gasket>();
            CreateMap<EditGasket, AddGasket>();
        }
    }
}
