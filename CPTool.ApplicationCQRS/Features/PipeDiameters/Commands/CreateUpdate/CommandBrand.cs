using CPTool.ApplicationCQRS.Features.Nozzles.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PipeAccesorys.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PipeClasss.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PipingItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Units.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Responses;
using CPTool.UnitsSystem;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.PipeDiameters.Commands.CreateUpdate
{
    public class CommandPipeDiameter : CommandBase, IRequest<PipeDiameterCommandResponse>
    {


        public CommandPipeDiameter()
        {
            OuterDiameter.Name = "Outer diameter";
            InternalDiameter.Name = "Inner diameter";
            Thickness.Name = "Thickness";
            OuterDiameter.Amount!.OnValueChanged += CalculateInternalDiameter;
            Thickness.Amount!.OnValueChanged += CalculateInternalDiameter;

        }
      
        public List<CommandPipingItem>? PipingItems { get; set; } = null!;
        public List<CommandNozzle>? Nozzles { get; set; } = null!;
        public int? OuterDiameterId => OuterDiameter == null ? null : OuterDiameter.Id;
        public CommandUnit OuterDiameter { get; set; } = new(LengthUnits.Inch);
        public int? InternalDiameterId => InternalDiameter == null ? null : InternalDiameter.Id;
        public CommandUnit InternalDiameter { get; set; } = new(LengthUnits.Inch);


        public int? ThicknessId => Thickness == null ? null : Thickness.Id;
        public CommandUnit Thickness { get; set; } = new(LengthUnits.Inch);

        public int? dPipeClassId => dPipeClass == null ? null : dPipeClass?.Id;
        public CommandPipeClass? dPipeClass { get; set; }


        public List<CommandPipeAccesory>? PipeAccesorys { get; set; } = new();

        public List<CommandPipeAccesory>? PipeAccesoryOthers { get; set; } = new();
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
