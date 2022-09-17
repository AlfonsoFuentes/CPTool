


namespace CPTool.Pages.Components
{
    public partial class ComponentTableList<TDTO, T> : CancellableComponent
        where TDTO : AuditableEntityDTO, new()
        where T : AuditableEntity, new()
    {

       
        private bool dense = true;
        [Parameter]
        public RenderFragment OtherButtons { get; set; }
        [Parameter]
        public RenderFragment ContextTh { get; set; }
        [Parameter]
        public RenderFragment<TDTO> ContextTd { get; set; }



        [Parameter]
        
        public List<TDTO> Elements { get; set; } = new();
        [Parameter]
        public TDTO SelectedItem { get; set; } = new();

        [Parameter]
        public string TableName { get; set; }
        [Parameter]
        public EventCallback<TDTO> OnRowClickEvent { get; set; }

        [Parameter]
        public Func<TDTO, Task<DialogResult>> OnShowDialogOverrided { get; set; }

        [Parameter]
        public EventCallback OnUpdateMaster { get; set; }
      
        private bool hover = true;
        private bool striped = true;
        private bool bordered = true;
        private string searchString1 = "";
        public IResult<List<TDTO>> Result { get; set; }
        private bool FilterFunc1(TDTO element) => FilterFunc(element, searchString1);

        [Parameter]
        public Func<TDTO,string, bool> SearchFunc { get; set; } = null;
       



        private bool FilterFunc(TDTO element, string searchString)
        {
            var retorno = SearchFunc == null ? element.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) : SearchFunc.Invoke(element,searchString);
            return retorno;

           
        }


        async Task RowClickEvent(TableRowClickEventArgs<TDTO> arg)
        {
            SelectedItem = arg.Item;
            await OnRowClickEvent.InvokeAsync(SelectedItem);
        }




        public async Task<IResult<int>> DeleteFromDialog(TDTO dto)
        {

            var resultdelete =await TablesService.OnDelete(SelectedItem);
            if (resultdelete.Succeeded)
            {
               
                Snackbar.Add(resultdelete.Messages[0], MudBlazor.Severity.Info);

                

            }
            else
            {
                Snackbar.Add($"{dto.Name} delete failed!", MudBlazor.Severity.Error);
            }
            return resultdelete;
        }
        async Task Add()
        {
            await AddEdit(new TDTO());

        }

        async Task Edit()
        {
            await AddEdit(SelectedItem);
        }
        async Task AddEdit(TDTO dto)
        {
            var result = OnShowDialogOverrided==null? await ShowDialog(dto): await OnShowDialogOverrided.Invoke(dto);
            
            if (!result.Cancelled)
            {
                var result2 = await TablesService.OnSave(result.Data as IAuditableEntityDTO);
               
                if (result2.Succeeded)
                {

                   
                    Snackbar.Add(result2.Messages[0], MudBlazor.Severity.Info);
                    StateHasChanged();
                }
                else
                {
                    Snackbar.Add(result2.Messages[0], MudBlazor.Severity.Error);
                }
               

            }
        }
        async Task<DialogResult> ShowDialog(TDTO dto)
        {

            return await ToolDialogService.ShowDialogName<TDTO>(dto);

        }
        async Task Delete()
        {



            var result = await ToolDialogService.ShowMessageDialogYesNo($"Are you sure you want to remove {SelectedItem.Name}?");
            if (!result.Cancelled)
            {
             await  TablesService.OnDelete(SelectedItem);


                StateHasChanged();
            }
        }
        void Print()
        {

        }
        void Excel()
        {

        }
        void PDF()
        {

        }

    }
}
