





using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.PipeAccesoryFeatures.CreateEdit;
using CPTool.Application.Features.PipeDiameterFeatures.CreateEdit;
using CPTool.Application.Features.ProcessConditionFeatures.CreateEdit;
using CPTool.UnitsSystem;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPTool.Application.Features.UnitFeatures.CreateEdit
{
    public class AddUnit : AddCommand, IRequest<Result<int>>
    {
        public AddUnit()
        {

        }
        public AddUnit(CPTool.UnitsSystem.Unit unit)
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
        public List<CPTool.UnitsSystem.Unit> UnitsList=>Amount!.UnitsList;


        public string StringValue => $"{Value} {UnitName}";
    }
}
