
using MediatR;
using MudBlazor;

namespace CPTool.NewPages.Components
{
    public partial class ManyToManyComponent<TMasterDetail, TMaster, TDetail, TMasterList, TDetailList, TDeleteMaster, TDeleteDetail>
         where TMasterDetail : AddEditCommand, new()
        where TMaster : AddEditCommand, new()
        where TDetail : AddEditCommand, new()
        where TMasterList : GetListQuery, new()
         where TDetailList : GetListQuery, new()
         where TDeleteMaster : DeleteCommand, new()
         where TDeleteDetail : DeleteCommand, new()

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
        public EventCallback<List<TMaster>> ElementsMastersChanged { get; set; }
        [Parameter]

        public List<TDetail> ElementsDetails { get; set; } = new();
        [Parameter]
        public EventCallback<List<TDetail>> ElementsDetailsChanged { get; set; }

        [Parameter]
        public TMaster SelectedMaster { get; set; } = new();
        [Parameter]
        public EventCallback<TMaster> SelectedMasterChanged { get; set; }

        [Parameter]
        public TDetail SelectedDetail { get; set; } = new();
        [Parameter]
        public EventCallback<TDetail> SelectedDetailChanged { get; set; }

        [Parameter]
        public RenderFragment MasterContextTh { get; set; }
        [Parameter]
        public RenderFragment<TMaster> MasterContextTd { get; set; }

        [Parameter]
        public RenderFragment DetailContextTh { get; set; }
        [Parameter]
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
            model.CreateMasterRelations(new TMaster(), SelectedDetail);


            var result = await OnShowDialogMaster(model);
            if (!result.Cancelled)
            {
                SelectedMaster = result.Data as TMaster;
                ElementsMasters = (await mediator.Send(MasterList)) as List<TMaster>;
                SelectedMaster = ElementsMasters.FirstOrDefault(x => x.Id == SelectedMaster.Id);

                await ElementsMastersChanged.InvokeAsync(ElementsMasters);
                await OnRowClickedMaster.InvokeAsync(SelectedMaster);
         
            }

        }
        async void AddDetail()
        {
            TMasterDetail model = new();
            model.CreateMasterRelations(SelectedMaster, new TDetail());


            var result = await OnShowDialogDetails(model);
            if (!result.Cancelled)
            {
                SelectedDetail = result.Data as TDetail;

                ElementsDetails = (await mediator.Send(DetailList)) as List<TDetail>;

                SelectedDetail= ElementsDetails.FirstOrDefault(x=>x.Id==SelectedDetail.Id);
                await ElementsDetailsChanged.InvokeAsync(ElementsDetails);
                await OnRowClickedDetails.InvokeAsync(SelectedDetail);
             
            }

        }

        async void EditMaster()
        {


            TMasterDetail model = new();
            model.CreateMasterRelations(SelectedMaster, SelectedDetail);


            var result = await OnShowDialogMaster(model);
            if (!result.Cancelled)
            {
                SelectedMaster = result.Data as TMaster;
                ElementsMasters = (await mediator.Send(MasterList)) as List<TMaster>;
                SelectedMaster = ElementsMasters.FirstOrDefault(x => x.Id == SelectedMaster.Id);

                await ElementsMastersChanged.InvokeAsync(ElementsMasters);
                await OnRowClickedMaster.InvokeAsync(SelectedMaster);
            }

        }
        async void EditDetails()
        {


            TMasterDetail model = new();
            model.CreateMasterRelations(SelectedMaster, SelectedDetail);
            var result = await OnShowDialogDetails(model);
            if (!result.Cancelled)
            {
                SelectedDetail = result.Data as TDetail;

                ElementsDetails = (await mediator.Send(DetailList)) as List<TDetail>;

                SelectedDetail = ElementsDetails.FirstOrDefault(x => x.Id == SelectedDetail.Id);
                await ElementsDetailsChanged.InvokeAsync(ElementsDetails);
                await OnRowClickedDetails.InvokeAsync(SelectedDetail);

            }

        }
        async Task DeleteMaster()
        {
            TDeleteMaster ModelDelete = new() { Id = SelectedMaster.Id, Name = SelectedMaster.Name };

            var result = await ToolDialogService.DeleteRow(ModelDelete);

            if (!result.Cancelled)
            {
                SelectedMaster = new();
                ElementsMasters = (await mediator.Send(MasterList)) as List<TMaster>;
                await ElementsMastersChanged.InvokeAsync(ElementsMasters);
                await OnRowClickedMaster.InvokeAsync(SelectedMaster);
            }


        }
        async Task DeleteDetails()
        {
            TDeleteDetail ModelDelete = new() { Id = SelectedDetail.Id, Name = SelectedDetail.Name };

            var result = await ToolDialogService.DeleteRow(ModelDelete);

            if (!result.Cancelled)
            {
                SelectedDetail = new();
                ElementsDetails = (await mediator.Send(DetailList)) as List<TDetail>;
                await ElementsDetailsChanged.InvokeAsync(ElementsDetails);
                await OnRowClickedDetails.InvokeAsync(SelectedDetail);
            }


        }
    }
}
