using CPTool.Application.Features.Base.Delete;
using CPTool.Application.Features.Base;
using Microsoft.AspNetCore.Components;
using CPTool.Application.Features.MMOTypeFeatures.CreateEdit;
using Radzen.Blazor;
using CPTool.Application.Features.MMOTypeFeatures.Query.GetList;
using CPTool.Domain.Entities;
using CPTool.Services;
using CPToolRadzen.Pages.MWOTypes.Dialog;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using CPTool.Application.Features.MMOTypeFeatures;
using CPtool.ExtensionMethods;
using CPToolRadzen.Services;
using System.Xml.Linq;
using CPTool.Persistence.BaseClass;
using CPTool.ApplicationRadzen.FeaturesGeneric;
using System.Linq.Expressions;
using DocumentFormat.OpenXml.Drawing.Charts;

namespace CPToolRadzen.Templates
{
    public partial class TableTemplate<T> where T : EditCommand, new()

    {

        [Inject]
        public ICommandQuery<T> CommandQuery { get; set; }
        [Parameter]
        public List<T> GlobalElements { get; set; } = new();
        [Parameter]
        public EventCallback<List<T>> GlobalElementsChanged { get; set; }

        [Parameter]
        public string TableName { get; set; }
        [Parameter]
        public List<T> Elements { get; set; } = new();
        [Parameter]
        public RenderFragment Columns { get; set; }

        [Parameter]
        public RenderFragment ToolBarButtons { get; set; }
        int SelectedItemId = 0;
        [Parameter]
        public T SelectedItem { get; set; } = new();
        [Parameter]
        public EventCallback<T> SelectedItemChanged { get; set; }
        bool DisableEditeButtons => SelectedItem.Id == 0 ? true : false;

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
        [Parameter]
        public Func<Task<bool>> OnPDF { get; set; }
        [Parameter]
        public Func<T, Task<bool>> ShowDialog { get; set; }

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
        async Task EditRowDoubleClick(DataGridCellMouseEventArgs<T> args)
        {
            if (InlineEdit)
                await grid0.EditRow(args.Data);
        }
        public async Task SaveRow(T order)
        {
            if (InlineEdit)
                await grid0.UpdateRow(order);
        }
       
        async Task ReloadGrid()
        {


            GlobalElements = await CommandQuery.GetAll();
            await GlobalElementsChanged.InvokeAsync(GlobalElements);
            await grid0.Reload();
            if (SelectedItemId == 0)
            {
                await grid0.Reload();
                return;
            }

            SelectedItem = await CommandQuery.GetById(SelectedItemId);
            await SelectedItemChanged.InvokeAsync(SelectedItem);
            await grid0.Reload();

        }


        protected async Task RowClick(DataGridRowMouseEventArgs<T> args)
        {
            SelectedItem = args.Data;
            SelectedItemId = SelectedItem.Id;
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
            if (OnAdd != null)
            {
                result = await OnAdd.Invoke(new());

            }
            else
            {
                if (ShowDialog != null)
                {
                    result = await ShowDialog.Invoke(new());

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
                    // DeleteMWOType delete = new() { Id = SelectedItem.Id };
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
        protected Func<T, bool> predicate = null!;
        protected Expression<Func<T, bool>> Expresion = null!;
        protected async Task Search(ChangeEventArgs args)
        {
            search = $"{args.Value}";

            await grid0.GoToPage(0);

            var QueryFilter = new QueryFilter { Filter = $@"i => i.Name.Contains(@0)", FilterParameters = new object[] { search } };



            Elements = await CommandQuery.GetAll();

            Elements = predicate == null ? Elements : Elements.Where(predicate).ToList();
        }

        //protected async Task ExportClick(RadzenSplitButtonItem args)
        //{
        //    var query = new QueryFilter
        //    {
        //        Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter) ? "true" : grid0.Query.Filter)}",
        //        OrderBy = $"{grid0.Query.OrderBy}",
        //        Expand = "",
        //        Select = string.Join(",", grid0.ColumnsCollection.Where(c => c.GetVisible()).Select(c => c.Property))
        //    };
        //    if (args?.Value == "csv")
        //    {
        //        await CommandQuery.ExportToCSV(query, "report");
        //    }
        //    else if (args?.Value == "xlsx")
        //    {
        //        await CommandQuery.ExportToExcel(query, "report");
        //    }



        //}
    }
}
