using CPTool.UnitsSystem;

namespace CPTool.Application.Features.UnitFeatures.CreateEdit
{
    public class EditUnit : EditCommand, IRequest<Result<int>>
    {
        public EditUnit()
        {

        }
        public EditUnit(CPTool.UnitsSystem.Unit unit)
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

        [Report]
        public string StringValue => Amount!.ToString("NG");
    }
}
