
using CPTool.Application.Features.SignalTypesFeatures.CreateEdit;
using CPToolRadzen.Pages.SignalType.Dialog;


namespace CPToolRadzen.Pages.SignalType.List
{
    public partial class SignalTypeList : BaseTableTemplate<EditSignalType>
    {

        public override List<EditSignalType> Elements => RadzenTables.SignalTypes;


        protected override void OnInitialized()
        {
            TableName = "Signal Type";
         
            base.OnInitialized();
        }
        public async Task<bool> ShowDialog(EditSignalType model)
        {

            var result = await DialogService.OpenAsync<SignalTypeDialog>(model.Id == 0 ? $"Add new {TableName}" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } });
            if (result == null) return false;
            return (bool)result;

        }
    }
}
