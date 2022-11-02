using CPtool.ExtensionMethods;
using CPTool.Application.Features.Base.DeleteCommand;

namespace CPTool.NewPages.Components
{
    public partial class DetailListComponent<TDetail, TDetailList, TDeleteDetail, TDetailGedById>
        where TDetail : EditCommand, new()
        where TDetailList : GetListQuery, new()

        where TDeleteDetail : DeleteCommand, new()

        where TDetailGedById : GetByIdQuery, new()
    {
        [Inject]
        public IMediator mediator { get; set; }


        TDetailList DetailList { get; set; } = new();


        [Parameter]

        public List<TDetail> ElementsDetails { get; set; } = new();
       
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
            TDetailGedById getbyid = new()
            {
                Id = eq.Item.Id,
            };
            SelectedDetail = await mediator.Send(getbyid) as TDetail;
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

                    
                    await UpdateParentList.InvokeAsync();
                    await SelectedDetailChanged.InvokeAsync(SelectedDetail);
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

                    
                    await UpdateParentList.InvokeAsync();
                    await SelectedDetailChanged.InvokeAsync(SelectedDetail);
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
                await UpdateParentList.InvokeAsync();

            }


        }

    }
}

