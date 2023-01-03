using CPtool.ExtensionMethods;
using CPTool.ApplicationCQRS.Responses;
using CPTool.UnitsSystem;
using MediatR;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPTool.ApplicationCQRS.Features.Units.Commands.CreateUpdate
{
    public class CommandUnit : CommandBase, IRequest<UnitCommandResponse>
    {

        public CommandUnit()
        {

        }
        public CommandUnit(CPTool.UnitsSystem.Unit unit)
        {
            Amount = new(unit);

        }

        public string? UnitName
        {
            get
            {
                return Amount!.UnitName;
            }
            set
            {
                if (Amount == null)
                {
                    Amount = new(value);
                }
                if (value != Amount!.UnitName)
                {
                    Amount!.UnitName = value;
                }
            }
        }

        public double Value
        {
            get
            {
                return Amount!.Value;
            }
            set
            {
                Amount!.SetValue(value, Amount!.Unit);
            }
        }
       
        public Amount? Amount { get; set; }
        public List<CPTool.UnitsSystem.Unit> UnitsList => Amount!.UnitsList;

      
        public string StringValue => Amount!.ToString("NG");


    }

}
