global using CPTool.Domain.Entities;
using AutoMapper;
using CPTool.ApplicationCQRS.Features.UnitaryBasePrizes.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.UnitaryBasePrizes.Profiles
{
    internal class UnitaryBasePrizeMapping : Profile
    {
        public UnitaryBasePrizeMapping()
        {
            CreateMap<UnitaryBasePrize, CommandUnitaryBasePrize>();
            CreateMap<CommandUnitaryBasePrize, UnitaryBasePrize>();
            CreateMap<AddUnitaryBasePrize, UnitaryBasePrize>();
            CreateMap<CommandUnitaryBasePrize, AddUnitaryBasePrize>();
        }
    }
}
