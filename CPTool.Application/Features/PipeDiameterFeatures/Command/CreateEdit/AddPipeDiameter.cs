





using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.PipeClassFeatures.CreateEdit;
using CPTool.Application.Features.PipingItemFeatures.CreateEdit;
using CPTool.Application.Features.UnitFeatures.CreateEdit;
using CPTool.UnitsSystem;

namespace CPTool.Application.Features.PipeDiameterFeatures.CreateEdit
{
    public class AddPipeDiameter : AddCommand, IRequest<Result<int>>,IDisposable
    {
        public AddPipeDiameter()
        {
            
            OD.Amount!.OnValueChanged += CalculateInternalDiameter;
            Thickness.Amount!.OnValueChanged += CalculateInternalDiameter;
            OD.Name = "Outer Diameter";
            ID.Name = "Inner Diameter";
            Thickness.Name = "Thickness";
        }
       
        //public int? ODId => OD.Id == 0 ? null : OD.Id;
        public AddUnit OD { get; set; } = new(LengthUnits.Inch);
        //public int? IDId => ID.Id == 0 ? null : ID.Id;
        public AddUnit ID { get; set; } = new(LengthUnits.Inch);


        //public int? ThicknessId => Thickness.Id == 0 ? null : Thickness.Id;
        public AddUnit Thickness { get; set; } = new(LengthUnits.Inch);

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
