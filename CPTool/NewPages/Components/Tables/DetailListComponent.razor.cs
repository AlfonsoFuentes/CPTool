using CPtool.ExtensionMethods;
using CPTool.Application.Features.Base.Delete;

namespace CPTool.NewPages.Components.Tables
{
    public partial class DetailListComponent<TDetail, TDetailList, TDeleteDetail, TDetailGedById>
        where TDetail : EditCommand, new()
        where TDetailList : GetListQuery, new()

        where TDeleteDetail : DeleteCommand, new()

        where TDetailGedById : GetByIdQuery, new()
    {

        [Parameter]
        [Category("Footer")]
        public RenderFragment FooterContentDetails { get; set; }
        TDetailList DetailList { get; set; } = new();

        [Parameter]
        [Category("Grouping")]
        public RenderFragment<TableGroupData<object, TDetail>> GroupFooterTemplateDetail { get; set; }

        [Parameter]
        public List<TDetail> ElementsDetails { get; set; } = new();
        public EventCallback<List<TDetail>> ElementsDetailsChanged { get; set; }
        [Parameter]
        [EditorRequired]
        public EditCommand SelectedMaster { get; set; } = new();

        [Parameter]

        public TDetail SelectedDetail { get; set; } = new();
        [Parameter]
        public EventCallback<TDetail> SelectedDetailChanged { get; set; }

        //This event is for Update List Master in Master details Relations via GetByIdQuery in master form

        [Parameter]
        public RenderFragment OtherButtons { get; set; }

        [Parameter]
        public RenderFragment DetailContextTh { get; set; }
        [Parameter]
        public RenderFragment<TDetail> DetailContextTd { get; set; }
        [Parameter]
        [EditorRequired]
        public Func<TDetail, Task<DialogResult>> OnShowDialogDetails { get; set; }

        [Parameter]
        [EditorRequired]
        public EventCallback UpdateParentList { get; set; }
        async Task RowClickedDetail(TableRowClickEventArgs<TDetail> eq)
        {
            if (eq.Item.Id == SelectedDetail.Id) return;
            
            SelectedDetail = eq.Item;
            await SelectedDetailChanged.InvokeAsync(SelectedDetail);
        }
     

        async Task AddDetail()
        {
            TDetail modeladd = SelectedMaster.AddDetailtoMaster<TDetail>();

            var result = await OnShowDialogDetails.Invoke(modeladd);
            if (!result.Cancelled)
            {
                if (result.Data is TDetail)
                {
                    SelectedDetail = result.Data as TDetail;

                    await UpdateTables();
                }
            }





        }

        async Task EditDetail()
        {
            var result = await OnShowDialogDetails.Invoke(SelectedDetail);

            if (!result.Cancelled)
            {
                if (result.Data is TDetail)
                {
                    SelectedDetail = result.Data as TDetail;

                    await UpdateTables();
                }
            }

        }

        async Task DeleteDetail()
        {
            TDeleteDetail deleteDetail = new() { Id = SelectedDetail.Id, Name = SelectedDetail.Name };

            var result = await ToolDialogService.DeleteRow(deleteDetail);
            if (!result.Cancelled)
            {
                SelectedDetail = new();
                await UpdateTables();

            }


        }
        async Task UpdateTables()
        {


            ElementsDetails = await Mediator.Send(DetailList) as List<TDetail>;
            await ElementsDetailsChanged.InvokeAsync(ElementsDetails);

            TDetailGedById querydetail = new() { Id = SelectedDetail.Id };
            SelectedDetail = await Mediator.Send(querydetail) as TDetail;
            await SelectedDetailChanged.InvokeAsync(SelectedDetail);

            await UpdateParentList.InvokeAsync();
        }
    }
}

