


using static MudBlazor.CategoryTypes;

namespace CPTool.Pages.Dialogs.MWOItemPage
{
    public partial class ExpenseComponent : CancellableComponent, IDisposable
    {
        [CascadingParameter]
        protected MWOItemDialog Dialog { get; set; }
        protected MWOItemDTO Model => Dialog.Model;

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
        private string ValidateUnitaryPrizeName(string arg)
        {
            if (arg == null || arg == "")
                return "Must submit Unitary prize";
            if (!TablesService.ManUnitaryPrize.List.Any(x => x.Name == arg))
                return $"Unitary prize: {arg} is not in the list";
            return null;
        }
        async Task UpdateUnitaryPrizeName()
        {
            await TablesService.ManUnitaryPrize.UpdateList();
            StateHasChanged();
            
        }
    }
}
