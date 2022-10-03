



using CPTool.Application.Features.GasketsFeatures.Command.CreateEdit;


namespace CPTool.Application.Features.GasketsFeatures.Mapping
{
    internal class GasketMapping : Profile
    {
        public GasketMapping()
        {
            CreateMap<Gasket, AddEditGasketCommand>();

            CreateMap<AddEditGasketCommand, Gasket>();
        }
    }
}
