





using CPTool.Application.Features.EquipmentItemFeatures.CreateEdit;
using CPTool.Application.Features.InstrumentItemFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.PipingItemFeatures.CreateEdit;

namespace CPTool.Application.Features.ProcessFluidFeatures.CreateEdit
{
    public class AddProcessFluid : AddCommand
    {
        public int? PropertyPackageId { get; set; }
        public string TagLetter { get; set; } = "";

    }
}
