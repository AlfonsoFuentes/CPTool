



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
                .ForMember(dest => dest.EquipmentItemCommand, act => { act.PreCondition(src => (src.EquipmentItem != null)); act.MapFrom(src => src.EquipmentItem); })
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
               .ForMember(dest => dest.AlterationItem, act => { act.PreCondition(src => (src.AlterationItemCommand != null)); act.MapFrom(src => src.AlterationItemCommand); })
                .ForMember(dest => dest.FoundationItem, act => { act.PreCondition(src => (src.FoundationItemCommand != null)); act.MapFrom(src => src.FoundationItemCommand); })
                .ForMember(dest => dest.StructuralItem, act => { act.PreCondition(src => (src.StructuralItemCommand != null)); act.MapFrom(src => src.StructuralItemCommand); })
                .ForMember(dest => dest.EquipmentItem, act => { act.PreCondition(src => (src.EquipmentItemCommand != null)); act.MapFrom(src => src.EquipmentItemCommand); }) 
                .ForMember(dest => dest.ElectricalItem, act => { act.PreCondition(src => (src.ElectricalItemCommand != null)); act.MapFrom(src => src.ElectricalItemCommand); })
                .ForMember(dest => dest.PipingItem, act => { act.PreCondition(src => (src.PipingItemCommand != null)); act.MapFrom(src => src.PipingItemCommand); })
                .ForMember(dest => dest.InstrumentItem, act => { act.PreCondition(src => (src.InstrumentItemCommand != null)); act.MapFrom(src => src.InstrumentItemCommand); })
                .ForMember(dest => dest.InsulationItem, act => { act.PreCondition(src => (src.InsulationItemCommand != null)); act.MapFrom(src => src.InsulationItemCommand); })
                .ForMember(dest => dest.PaintingItem, act => { act.PreCondition(src => (src.PaintingItemCommand != null)); act.MapFrom(src => src.PaintingItemCommand); })
                .ForMember(dest => dest.EHSItem, act => { act.PreCondition(src => (src.EHSItemCommand != null)); act.MapFrom(src => src.EHSItemCommand); })
                .ForMember(dest => dest.TaxesItem, act => { act.PreCondition(src => (src.TaxesItemCommand != null)); act.MapFrom(src => src.TaxesItemCommand); })
                .ForMember(dest => dest.TestingItem, act => { act.PreCondition(src => (src.TestingItemCommand != null)); act.MapFrom(src => src.TestingItemCommand); })
                .ForMember(dest => dest.ContingencyItem, act => { act.PreCondition(src => (src.ContingencyItemCommand != null)); act.MapFrom(src => src.ContingencyItemCommand); })
                .ForMember(dest => dest.EngineeringCostItem, act => { act.PreCondition(src => (src.ChapterCommand != null)); act.MapFrom(src => src.EngineeringCostItemCommand); });

        }
    }
    
}
