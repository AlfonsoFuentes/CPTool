


namespace CPTool.Pages.Dialogs.MWOItemPage
{
    public partial class ExpenseComponent : CancellableComponent, IDisposable
    {
        [CascadingParameter]
        protected MWOItemDTO Model { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }


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
    }
}
