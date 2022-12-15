





using CPTool.Application.Features.InstrumentItemFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Domain.Entities;
using CPTool.UnitsSystem;

namespace CPTool.Application.Features.MeasuredVariableFeatures.CreateEdit
{
    public class EditMeasuredVariable : EditCommand, IRequest<Result<int>>
    {
        [Report(Order = 3)]
        public string? TagLetter { get; set; }

      


    }
}
