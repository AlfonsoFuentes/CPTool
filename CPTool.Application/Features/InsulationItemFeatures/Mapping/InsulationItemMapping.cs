﻿



using CPTool.Application.Features.InsulationItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.InsulationItemFeatures.Mapping
{
    internal class InsulationItemMapping : Profile
    {
        public InsulationItemMapping()
        {
            CreateMap<InsulationItem, AddEditInsulationItemCommand>()
                .ForMember(dest => dest.MWOItemsCommand, act => { act.PreCondition(src => (src.MWOItems != null)); act.MapFrom(src => src.MWOItems); });
           

            CreateMap<AddEditInsulationItemCommand, InsulationItem>();
        }
    }
}