using CPTool.Application.Features.EquipmentItemFeatures.CreateEdit;
using CPTool.Application.Features.InstrumentItemFeatures.CreateEdit;
using CPTool.Application.Features.PipingItemFeatures.CreateEdit;

namespace CPTool.Application.Features.ProcessFluidFeatures.CreateEdit
{
    public class EditProcessFluid : EditCommand, IRequest<Result<int>>
    {

        public string TagLetter { get; set; } = "";

    }
}
