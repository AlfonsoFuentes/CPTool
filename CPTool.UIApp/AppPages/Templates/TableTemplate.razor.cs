using BlazorDownloadFile;
using CPTool.Application.Generic;
using CPTool.Persistence.BaseClass;
using Microsoft.AspNetCore.Components;
using Radzen.Blazor;
using Radzen;
using CPTool.ApplicationCQRS.Responses;

namespace CPTool.UIApp.AppPages.Templates
{
    public partial class TableTemplate<T> where T : CommandBase, new()

    {
        [Inject]
        private IBlazorDownloadFileService _blazorDownloadFileService { get; set; } = null!;

        [Parameter]
        public List<T> Elements { get; set; }


        [Parameter]
        public string TableName { get; set; }
        [Parameter]
        public Func<T, bool> Filter { get; set; }
        [Parameter]
        public Func<List<T>> FilterFunc { get; set; }

        [Parameter]
        public RenderFragment Columns { get; set; }

        [Parameter]
        public bool ShowTemplate { get; set; } = false;

        [Parameter]
        public RenderFragment ToolBarButtons { get; set; }

        [Parameter]
        public T SelectedItem { get; set; } = new();
        [Parameter]
        public EventCallback<T> SelectedItemChanged { get; set; }
        protected bool DisableEditeButtons => (SelectedItem == null || SelectedItem.Id == 0) ? true : false;

        [Parameter]
        public bool ShowToolBar { get; set; } = true;

        [Parameter]
        public Func<T, Task<bool>> OnAdd { get; set; }
        [Parameter]
        public Func<T, Task<bool>> OnEdit { get; set; }
        [Parameter]

        public Func<T, Task<bool>> OnDelete { get; set; }

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


        int SelectedItemId = 0;
        [Parameter]
        public EventCallback<int> OnChangeItemId { get; set; }

        protected async Task RowClick(DataGridRowMouseEventArgs<T> args)
        {
            SelectedItem = args.Data;
            SelectedItemId = args.Data.Id;
            await SelectedItemChanged.InvokeAsync(SelectedItem);
            if (OnChangeItemId.HasDelegate)
                await OnChangeItemId.InvokeAsync(SelectedItemId);
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
            if (ShowDialog != null)
            {
                result = await ShowDialog.Invoke(SelectedItem);

            }

        }
        public async Task RefresheTable()
        {
            await grid0.Reload();
        }
        protected async Task AddRow()
        {
            bool result = false;
            SelectedItem = new();
            if (OnAdd != null)
            {
                result = await OnAdd.Invoke(SelectedItem);
            }
            else if (ShowDialog != null)
            {
                result = await ShowDialog.Invoke(SelectedItem);

            }

        }
        protected async Task DeleteRow()
        {
            try
            {
                if (SelectedItem != null && SelectedItem.Id != 0)
                {
                    if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                    {

                        var result = await OnDelete.Invoke(SelectedItem);

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
        [Parameter]
        public Func<string, Task<ExportBaseResponse>> Export { get; set; }

        protected async Task ExportClick(RadzenSplitButtonItem args)
        {


            if (Export != null)
            {
                var Result = await Export.Invoke(args.Value);
                if (Result != null)
                {
                    var downloadresult = await _blazorDownloadFileService.DownloadFile(Result.ExportFileName, Result.Data, contentType: Result.ContentType);



                }
            }




        }

        [Parameter]
        public int PageSize { get; set; } = 20;
        [Parameter]
        public EventCallback<int> OnPageChanged { get; set; }
        async void OnPage(PagerEventArgs args)
        {
            if (OnPageChanged.HasDelegate)
            {
                await OnPageChanged.InvokeAsync(args.PageIndex);
            }
        }
        bool debug = true;
        IList<T> SelectedItems;
        bool multiple = true;

        IList<Tuple<T, RadzenDataGridColumn<T>>> selectedCellData = new List<Tuple<T, RadzenDataGridColumn<T>>>();

        async Task Select(DataGridCellMouseEventArgs<T> args)
        {
            if (!multiple)
            {
                selectedCellData.Clear();
            }

            var cellData = selectedCellData.FirstOrDefault(i => i.Item1 == args.Data && i.Item2 == args.Column);
            if (cellData != null)
            {
                selectedCellData.Remove(cellData);
            }
            else
            {
                selectedCellData.Add(new Tuple<T, RadzenDataGridColumn<T>>(args.Data, args.Column));
            }
            await grid0.EditRow(args.Data);
        }

        async Task OnCellClick(DataGridCellMouseEventArgs<T> args)
        {
            if (InlineEdit)
            {
                await Select(args);

            }
            SelectedItem = args.Data;
            await SelectedItemChanged.InvokeAsync(SelectedItem);
        }

        async Task OnCellDoubleClick(DataGridCellMouseEventArgs<T> args)
        {
            if (InlineEdit)
            {
                await Select(args);

            }


        }

        void OnCellRender(DataGridCellRenderEventArgs<T> args)
        {
            if (selectedCellData.Any(i => i.Item1 == args.Data && i.Item2 == args.Column))
            {
                args.Attributes.Add("style", $"background-color: var(--rz-secondary-lighter);");
            }
        }

    }
}
