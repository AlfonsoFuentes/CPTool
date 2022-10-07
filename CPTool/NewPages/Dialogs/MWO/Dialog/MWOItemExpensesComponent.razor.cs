using CPTool.Application.Features.ChapterFeatures.Command.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.Command.CreateEdit;


namespace CPTool.NewPages.Dialogs.MWO.Dialog
{
    public partial class MWOItemExpensesComponent
    {
        [CascadingParameter]
        protected MWOItemDialog DialogParent { get; set; }
        protected AddEditMWOItemCommand Model => DialogParent.Model;

        
        string ValidateUnitaryPrize(double valor)
        {

            if (valor < 0)
                return "Unitary prize must be greater than zero";
            return null;
        }
        string ValidateQuantity(double valor)
        {

            if (valor < 0)
                return "Quantity must be greater than zero";
            return null;
        }
        private string ValidateUnitaryPrizeName(string arg)
        {
            if (arg == null || arg == "")
                return "Must submit Unitary prize";
            if (!Global.UnitaryBasePrizes.Any(x => x.Name == arg))
                return $"Unitary prize: {arg} is not in the list";
            return null;
        }

    }
}
