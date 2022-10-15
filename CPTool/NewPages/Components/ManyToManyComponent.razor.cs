
using CPTool.Application.Features.Base.DeleteCommand;
using MediatR;
using MudBlazor;

namespace CPTool.NewPages.Components
{
    public partial class ManyToManyComponent<TMasterDetail, TMaster, TAddMaster, TDetail, TAddDetail, TMasterList, TDetailList, TDeleteMaster, TDeleteDetail>
         where TMasterDetail : EditCommand, new()
        where TMaster : EditCommand, new()
        where TAddMaster : AddCommand, new()
        where TDetail : EditCommand, new()
        where TAddDetail : AddCommand, new()
        where TMasterList : GetListQuery, new()
         where TDetailList : GetListQuery, new()
         where TDeleteMaster : Delete, new()
         where TDeleteDetail : Delete, new()

    {
        [Inject]
        public IMediator mediator { get; set; }

        TMasterList MasterList = new();
        TDetailList DetailList = new();

        [Parameter]
        public RenderFragment OtherButtonsMaster { get; set; }
        [Parameter]
        public RenderFragment OtherButtonsDetails { get; set; }
        [Parameter]

        public List<TMaster> ElementsMasters { get; set; } = new();

        [Parameter]

        public List<TDetail> ElementsDetails { get; set; } = new();


        [Parameter]
        public TMaster SelectedMaster { get; set; } = new();
        [Parameter]
        public EventCallback<TMaster> SelectedMasterChanged { get; set; }

        [Parameter]
        public TDetail SelectedDetail { get; set; } = new();
        [Parameter]
        public EventCallback<TDetail> SelectedDetailChanged { get; set; }

        [Parameter]
        [EditorRequired]
        public RenderFragment MasterContextTh { get; set; }
        [Parameter]
        [EditorRequired]
        public RenderFragment<TMaster> MasterContextTd { get; set; }

        [Parameter]
        [EditorRequired]
        public RenderFragment DetailContextTh { get; set; }
        [Parameter]
        [EditorRequired]
        public RenderFragment<TDetail> DetailContextTd { get; set; }
        [Parameter]
        [EditorRequired]
        public EventCallback<TMaster> OnRowClickedMaster { get; set; }


        [Parameter]
        [EditorRequired]
        public EventCallback<TDetail> OnRowClickedDetails { get; set; }

        [Parameter]
        [EditorRequired]
        public Func<TMasterDetail, Task<DialogResult>> OnShowDialogMaster { get; set; }
        [Parameter]
        [EditorRequired]
        public Func<TMasterDetail, Task<DialogResult>> OnShowDialogDetails { get; set; }

        async Task RowClickedMaster(TableRowClickEventArgs<TMaster> row)
        {
            await OnRowClickedMaster.InvokeAsync(row.Item);
        }
        async Task RowClickedDetails(TableRowClickEventArgs<TDetail> row)
        {
            await OnRowClickedDetails.InvokeAsync(row.Item);
        }
        async void AddMaster()
        {
            TMasterDetail model = new();
            SelectedMaster = new TMaster();
            model.CreateMasterRelations(SelectedMaster, SelectedDetail);


            var result = await OnShowDialogMaster(model);
            if (!result.Cancelled)
            {
                var resultmodel = result.Data as TMaster;


                await OnRowClickedMaster.InvokeAsync(resultmodel);

            }

        }
        async void AddDetail()
        {
            TMasterDetail model = new();
            SelectedDetail = new TDetail();
            model.CreateMasterRelations(SelectedMaster, new TDetail());


            var result = await OnShowDialogDetails(model);
            if (!result.Cancelled)
            {
                var resultmodel = result.Data as TDetail;


                await OnRowClickedDetails.InvokeAsync(resultmodel);

            }

        }

        async void EditMaster()
        {


            TMasterDetail model = new();
            model.CreateMasterRelations(SelectedMaster, SelectedDetail);


            var result = await OnShowDialogMaster(model);
            if (!result.Cancelled)
            {
                var resultmodel = result.Data as TMaster;


                await OnRowClickedMaster.InvokeAsync(resultmodel);

            }

        }
        async void EditDetails()
        {


            TMasterDetail model = new();
            model.CreateMasterRelations(SelectedMaster, SelectedDetail);
            var result = await OnShowDialogDetails(model);
            if (!result.Cancelled)
            {

                var resultmodel = result.Data as TDetail;


                await OnRowClickedDetails.InvokeAsync(resultmodel);

            }

        }
        async Task DeleteMaster()
        {
            TDeleteMaster ModelDelete = new() { Id = SelectedMaster.Id, Name = SelectedMaster.Name };

            var result = await ToolDialogService.DeleteRow(ModelDelete);

            if (!result.Cancelled)
            {
                TMaster model = new();


                await OnRowClickedMaster.InvokeAsync(model);
            }


        }
        async Task DeleteDetails()
        {
            TDeleteDetail ModelDelete = new() { Id = SelectedDetail.Id, Name = SelectedDetail.Name };

            var result = await ToolDialogService.DeleteRow(ModelDelete);

            if (!result.Cancelled)
            {
                TDetail model = new();


                await OnRowClickedDetails.InvokeAsync(model);
            }


        }
    }
}
