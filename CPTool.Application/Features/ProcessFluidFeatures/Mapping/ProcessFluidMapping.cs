



using CPTool.Application.Features.ProcessFluidFeatures.CreateEdit;

namespace CPTool.Application.Features.ProcessFluidFeatures.Mapping
{
    internal class ProcessFluidMapping : Profile
    {
        public ProcessFluidMapping()
        {
            CreateMap<ProcessFluid, EditProcessFluid>();
            CreateMap<EditProcessFluid, ProcessFluid>();
            CreateMap<AddProcessFluid, ProcessFluid>();
            CreateMap<EditProcessFluid, AddProcessFluid>();
        }
    }
}
