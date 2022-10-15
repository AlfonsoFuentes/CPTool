using CPTool.Application.Features.EquipmentItemFeatures.CreateEdit;
using CPTool.Application.Features.InstrumentItemFeatures.CreateEdit;
using CPTool.Application.Features.PipingItemFeatures.CreateEdit;

namespace CPTool.Application.Features.ProcessFluidFeatures.CreateEdit
{
    public class EditProcessFluid : EditCommand, IRequest<Result<int>>
    {

        public List<EditEquipmentItem> EquipmentItems { get; set; } = new();
        public List<EditInstrumentItem> InstrumentItems { get; set; } = new();
        public List<EditPipingItem> PipingItems { get; set; } = new();

    }
}
