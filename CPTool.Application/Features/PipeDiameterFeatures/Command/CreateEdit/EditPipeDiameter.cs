using CPTool.Application.Features.NozzleFeatures.CreateEdit;
using CPTool.Application.Features.PipeAccesoryFeatures.CreateEdit;
using CPTool.Application.Features.PipeClassFeatures.CreateEdit;
using CPTool.Application.Features.PipeClassFeatures.Query.GetById;
using CPTool.Application.Features.PipeClassFeatures.Query.GetList;
using CPTool.Application.Features.PipeDiameterFeatures.Query.GetById;
using CPTool.Application.Features.PipeDiameterFeatures.Query.GetList;
using CPTool.Application.Features.PipingItemFeatures.CreateEdit;
using CPTool.Application.Features.UnitFeatures.CreateEdit;
using CPTool.UnitsSystem;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPTool.Application.Features.PipeDiameterFeatures.CreateEdit
{
    public class EditPipeDiameter : EditCommand, IRequest<Result<int>>, IDisposable
    {
         public EditPipeDiameter()
        {
            OuterDiameter.Name = "Outer diameter";
            InternalDiameter.Name = "Inner diameter";
            Thickness.Name = "Thickness";
            OuterDiameter.Amount!.OnValueChanged += CalculateInternalDiameter;
            Thickness.Amount!.OnValueChanged += CalculateInternalDiameter;

        }

        public List<EditPipingItem>? PipingItems { get; set; } = null!;
        public List<EditNozzle>? Nozzles { get; set; } = null!;
        public int? OuterDiameterId => OuterDiameter==null ? null : OuterDiameter.Id;
        public EditUnit OuterDiameter { get; set; } = new(LengthUnits.Inch);
        public int? InternalDiameterId => InternalDiameter == null  ? null : InternalDiameter.Id;
        public EditUnit InternalDiameter { get; set; } = new(LengthUnits.Inch);


        public int? ThicknessId => Thickness == null ? null : Thickness.Id;
        public EditUnit Thickness { get; set; } = new(LengthUnits.Inch);

        public int? dPipeClassId => dPipeClass== null ? null : dPipeClass?.Id;
        public EditPipeClass? dPipeClass { get; set; }

      
        public List<EditPipeAccesory>? PipeAccesorys { get; set; } = new();
      
        public List<EditPipeAccesory>? PipeAccesoryOthers { get; set; } = new();
        void CalculateInternalDiameter()
        {
            InternalDiameter.Amount = OuterDiameter.Amount - 2 * Thickness.Amount;
        }

        public void Dispose()
        {
            OuterDiameter.Amount!.OnValueChanged -= CalculateInternalDiameter;
            Thickness.Amount!.OnValueChanged -= CalculateInternalDiameter;
        }
    }

}
