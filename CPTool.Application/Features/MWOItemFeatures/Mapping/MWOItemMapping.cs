



using CPTool.Application.Features.MWOItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.MWOItemFeatures.Mapping
{
    internal class MWOItemMapping : Profile
    {
        public MWOItemMapping()
        {
            CreateMap<MWOItem, AddEditMWOItemCommand>()
                .ForMember(dest => dest.MWOCommand, act => { act.PreCondition(src => (src.MWO != null)); act.MapFrom(src => src.MWO); })
                .ForMember(dest => dest.UnitaryBasePrizeCommand, act => { act.PreCondition(src => (src.UnitaryBasePrize != null)); act.MapFrom(src => src.UnitaryBasePrize); })
                .ForMember(dest => dest.ChapterCommand, act => act.MapFrom(src => src.Chapter))
                .ForMember(dest => dest.AlterationItemCommand, act => { act.PreCondition(src => (src.AlterationItem != null)); act.MapFrom(src => src.AlterationItem); })
                .ForMember(dest => dest.FoundationItemCommand, act => { act.PreCondition(src => (src.FoundationItem != null)); act.MapFrom(src => src.FoundationItem); })
                .ForMember(dest => dest.StructuralItemCommand, act => { act.PreCondition(src => (src.StructuralItem != null)); act.MapFrom(src => src.StructuralItem); })
                .ForMember(dest => dest.EquipmentItemCommand, act => act.MapFrom(src => src.EquipmentItem))
                .ForMember(dest => dest.ElectricalItemCommand, act => { act.PreCondition(src => (src.ElectricalItem != null)); act.MapFrom(src => src.ElectricalItem); })
                .ForMember(dest => dest.PipingItemCommand, act => { act.PreCondition(src => (src.PipingItem != null)); act.MapFrom(src => src.PipingItem); })
                .ForMember(dest => dest.InstrumentItemCommand, act => { act.PreCondition(src => (src.InstrumentItem != null)); act.MapFrom(src => src.InstrumentItem); })
                .ForMember(dest => dest.InsulationItemCommand, act => { act.PreCondition(src => (src.InsulationItem != null)); act.MapFrom(src => src.InsulationItem); })
                .ForMember(dest => dest.PaintingItemCommand, act => { act.PreCondition(src => (src.PaintingItem != null)); act.MapFrom(src => src.PaintingItem); })
                .ForMember(dest => dest.EHSItemCommand, act => { act.PreCondition(src => (src.EHSItem != null)); act.MapFrom(src => src.EHSItem); })
                .ForMember(dest => dest.TaxesItemCommand, act => { act.PreCondition(src => (src.TaxesItem != null)); act.MapFrom(src => src.TaxesItem); })
                .ForMember(dest => dest.TestingItemCommand, act => { act.PreCondition(src => (src.TestingItem != null)); act.MapFrom(src => src.TestingItem); })
                .ForMember(dest => dest.ContingencyItemCommand, act => { act.PreCondition(src => (src.ContingencyItem != null)); act.MapFrom(src => src.ContingencyItem); })
                .ForMember(dest => dest.EngineeringCostItemCommand, act => { act.PreCondition(src => (src.Chapter != null)); act.MapFrom(src => src.EngineeringCostItem); });
           

            CreateMap<AddEditMWOItemCommand, MWOItem>()
                .ForMember(dest => dest.EquipmentItem, act => { act.PreCondition(src => (src.EquipmentItemCommand != null)); act.MapFrom(src => src.EquipmentItemCommand); });
        }
    }
    
}
