
using Microsoft.AspNetCore.Components;

using Radzen.Blazor;


using CPTool.Persistence.BaseClass;

using BlazorDownloadFile;
using CPTool.Application.Generic;

namespace CPToolRadzen.Templates
{
    public partial class TableTemplate<T> where T : EditCommand, new()

    {
        [Inject]
        private IBlazorDownloadFileService _blazorDownloadFileService { get; set; } = null!;
        [Inject]
        public ICommandQuery<T> CommandQuery { get; set; }
        [Parameter]
        public List<T> GlobalElements { get; set; }
        [Parameter]
        public EventCallback<List<T>> GlobalElementsChanged { get; set; }
        [Parameter]
        public int ParentId { get; set; }
        [Parameter]
        public string TableName { get; set; }
        [Parameter]
        public Func<T, bool> Filter { get; set; }
        [Parameter]
        public Func<List<T>> FilterFunc { get; set; }
        public List<T> Elements => FilterList();

        List<T> FilterList()
        {
            List<T> result = GlobalElements;
            if (Filter != null)
            {
                result = result.Where(Filter).ToList();


            }
            if (FilterFunc != null)
            {
                result = FilterFunc.Invoke();
            }
            if (search != "")
            {
                return CommandQuery.Search(search, result);
            }


            return result;


        }
        [Parameter]
        public RenderFragment Columns { get; set; }

        [Parameter]
        public RenderFragment ToolBarButtons { get; set; }

        [Parameter]
        public T SelectedItem { get; set; } = new();
        [Parameter]
        public EventCallback<T> SelectedItemChanged { get; set; }
        bool DisableEditeButtons =>(SelectedItem==null|| SelectedItem.Id == 0) ? true : false;

        [Parameter]
        public bool ShowToolBar { get; set; } = true;

        [Parameter]
        public Func<T, Task<bool>> OnAdd { get; set; }
        [Parameter]
        public Func<T, Task<bool>> OnEdit { get; set; }
        [Parameter]
        public Func<Task<bool>> OnDelete { get; set; }

        [Parameter]
        public Func<Task<bool>> OnExcel { get; set; }

        public Func<Task<bool>> OnPDF { get; set; }
        [Parameter]
        public virtual Func<T, Task<bool>> ShowDialog { get; set; }

        public RadzenDataGrid<T> grid0;
        [Parameter]
        public DataGridExpandMode ExpandMode { get; set; } = DataGridExpandMode.Single;
        [Parameter]
        public bool ShowAdd { get; set; } = true;
        [Parameter]

        public bool ShowEdit { get; set; } = true;
        [Parameter]

        public bool DisableAdd { get; set; } = false;
        [Parameter]

        public bool DisableEdit { get; set; } = false;
        [Parameter]

        public bool DisableDelete { get; set; } = false;
        [Parameter]

        public bool ShowDelete { get; set; } = true;
        [Parameter]

        public bool ShowReport { get; set; } = true;
        [Parameter]

        public bool DisableReport { get; set; } = false;
        [Parameter]

        public bool InlineEdit { get; set; } = false;

        public async Task SaveRow(T order)
        {
            if (InlineEdit)
                await grid0.UpdateRow(order);
        }

        async Task ReloadGrid()
        {


            GlobalElements = await CommandQuery.GetAll();

            await GlobalElementsChanged.InvokeAsync(GlobalElements);
            if (SelectedItemId == 0)
            {
                SelectedItem = new();
                await grid0.Reload();
                return;
            }

            SelectedItem = await CommandQuery.GetById(SelectedItem.Id);
            await SelectedItemChanged.InvokeAsync(SelectedItem);
            await grid0.Reload();

        }
        int SelectedItemId = 0;

        protected async Task RowClick(DataGridRowMouseEventArgs<T> args)
        {
            SelectedItem = args.Data;
            SelectedItemId = args.Data.Id;
            await SelectedItemChanged.InvokeAsync(SelectedItem);
        }
        protected async Task CreatePDF()
        {
            await Task.CompletedTask;
        }
        protected async Task EditRow()
        {
            bool result = false;
            if (OnEdit != null)
            {
                result = await OnEdit.Invoke(SelectedItem);

            }
            else
            {
                if (ShowDialog != null)
                {
                    result = await ShowDialog.Invoke(SelectedItem);

                }
            }
            if (result) await ReloadGrid();
        }
        protected async Task AddRow()
        {
            bool result = false;
            SelectedItem = new();
            if (OnAdd != null)
            {
                result = await OnAdd.Invoke(SelectedItem);

            }
            else
            {
                if (ShowDialog != null)
                {
                    result = await ShowDialog.Invoke(SelectedItem);

                }
            }
            if (result) await ReloadGrid();
        }
        protected async Task DeleteRow()
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {

                    var deleteResult = await CommandQuery.Delete(SelectedItem.Id);// await Mediator.Send(delete);// PMToolService.DeleteMwoType(mwoType.Id);

                    if (deleteResult.Succeeded)
                    {
                        
                        SelectedItemId = 0;
                        await ReloadGrid();
                    }
                }
            }
            catch (Exception ex)
            {
                NotificationService.Notify(new NotificationMessage
                {
                    Severity = NotificationSeverity.Error,
                    Summary = $"Error",
                    Detail = ex.Message,
                });
            }
        }
        protected string search = "";

        protected async Task ExportClick(RadzenSplitButtonItem args)
        {


            var result = await CommandQuery.ExportToExcel(Elements);
            if (result.Succeeded)
            {
                var downloadresult = await _blazorDownloadFileService.DownloadFile($"{CommandQuery.FileName}.xlsx", result.Data.Result, contentType: "application/octet-stream");

            }




        }
    }
}
