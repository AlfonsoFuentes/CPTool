

using CPToolRadzen.Pages.MWOItems.Dialog;

namespace CPToolRadzen.Pages.MWOItems.List
{
    public partial class MWOItemList : BaseTableTemplate<EditMWOItem>
    {
        public override List<EditMWOItem> Elements => RadzenTables.MWOItems.Where(x => x.MWOId == ParentId).ToList();

        EditMWO Parent => RadzenTables.MWOs.FirstOrDefault(x => x.Id == ParentId);

        protected override void OnInitialized()
        {
           
           
            base.OnInitialized();
        }
        public async Task<bool> ShowDialog(EditMWOItem model)
        {

            var result = await DialogService.OpenAsync<MWOItemDialog>(model.Id == 0 ? $"Add new Item" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } },
               new DialogOptions() { Width = "1200px", Height = "750px", Resizable = true, Draggable = true });
            if (result == null) return false;
            return (bool)result;

        }
    }
}
