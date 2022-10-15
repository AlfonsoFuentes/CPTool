





using CPTool.Application.Features.InstrumentItemFeatures.CreateEdit;

namespace CPTool.Application.Features.ReadoutFeatures.CreateEdit
{
    public class EditReadout : EditCommand
    {


        public List<EditInstrumentItem> InstrumentItems { get; set; } = new();
    }
   
}
