global using CPTool.Domain.Entities;
using AutoMapper;
using CPTool.ApplicationCQRS.Features.ProcessFluids.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.ProcessFluids.Profiles
{
    internal class ProcessFluidMapping : Profile
    {
        public ProcessFluidMapping()
        {
            CreateMap<ProcessFluid, CommandProcessFluid>();
            CreateMap<CommandProcessFluid, ProcessFluid>();
            CreateMap<AddProcessFluid, ProcessFluid>();
            CreateMap<CommandProcessFluid, AddProcessFluid>();
        }
    }
}
