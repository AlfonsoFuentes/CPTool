using CPTool.Application.Features.NozzleFeatures.CreateEdit;
using CPTool.Application.Features.PipeClassFeatures.CreateEdit;
using CPTool.Application.Features.PipingItemFeatures.CreateEdit;
using CPTool.Application.Features.UnitFeatures.CreateEdit;
using CPTool.UnitsSystem;

namespace CPTool.Application.Features.PipeDiameterFeatures.CreateEdit
{
    public class EditPipeDiameter : EditCommand, IRequest<Result<int>>, IDisposable
    {
       
        public List<EditPipingItem>? PipingItems { get; set; } = null!;
        public List<EditNozzle>? Nozzles { get; set; } = null!;
        //public int? ODId => OD.Id == 0 ? null : OD.Id;
        public EditUnit OD { get; set; } = new(LengthUnits.Inch);
        //public int? IDId => ID.Id == 0 ? null : ID.Id;
        public EditUnit ID { get; set; } = new(LengthUnits.Inch);


        public int? ThicknessId => Thickness.Id == 0 ? null : Thickness.Id;
        public EditUnit Thickness { get; set; } = new(LengthUnits.Inch);

        //public int? PipeClassId => PipeClass?.Id == 0 ? null : PipeClass?.Id;
        public EditPipeClass? PipeClass { get; set; } = new();

        void CalculateInternalDiameter()
        {
            ID.Amount = OD.Amount - 2 * Thickness.Amount;
        }

        public void Dispose()
        {
            OD.Amount!.OnValueChanged -= CalculateInternalDiameter;
            Thickness.Amount!.OnValueChanged -= CalculateInternalDiameter;
        }
    }

}
