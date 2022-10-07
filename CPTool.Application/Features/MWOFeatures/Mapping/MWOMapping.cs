﻿



using CPTool.Application.Features.MWOFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.MWOFeatures.Mapping
{
    internal class MWOMapping : Profile
    {
        public MWOMapping()
        {
            CreateMap<MWO, AddEditMWOCommand>()
                .ForMember(dest => dest.MWOItemsCommand, act => { act.PreCondition(src => (src.MWOItems != null)); act.MapFrom(src => src.MWOItems); }); ;

            CreateMap<AddEditMWOCommand, MWO>();
        }
    }
}