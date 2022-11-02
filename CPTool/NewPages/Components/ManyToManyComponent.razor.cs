
using CPtool.ExtensionMethods;
using CPTool.Application.Features.Base.DeleteCommand;
using CPTool.Application.Features.BrandFeatures.CreateEdit;
using CPTool.Application.Features.BrandFeatures.Query.GetById;
using CPTool.Application.Features.SupplierFeatures.CreateEdit;
using CPTool.Application.Features.SupplierFeatures.Query.GetById;
using CPTool.Domain.Entities;
using MediatR;
using MudBlazor;
using static MudBlazor.Icons.Custom;

namespace CPTool.NewPages.Components
{
    public partial class ManyToManyComponent<TMasterDetail, TMasterDetailList, TMaster,
        TDetail, TMasterList, TDetailList, TDeleteMaster, TDeleteDetail>
         where TMasterDetail : EditCommand, new()
        where TMaster : EditCommand, new()
        where TMasterDetailList : GetListQuery, new()
        where TDetail : EditCommand, new()

        where TMasterList : GetListQuery, new()
         where TDetailList : GetListQuery, new()
         where TDeleteMaster : DeleteCommand, new()
         where TDeleteDetail : DeleteCommand, new()

    {
        [Inject]
        public IMediator mediator { get; set; }

        TMasterList MasterList = new();
        TDetailList DetailList = new();
        TMasterDetailList MasterDetailList = new();

        [Parameter]
        public RenderFragment OtherButtonsMaster { get; set; }
        [Parameter]
        public RenderFragment OtherButtonsDetails { get; set; }
        [Parameter]
        public List<TMaster> ElementsMasters { get; set; } = new();

        [Parameter]
        public List<TDetail> ElementsDetails { get; set; } = new();
        [Parameter]
        public List<TMasterDetail> ElementsMastersDetails { get; set; } = new();
        [Parameter]
        public EventCallback<List<TMasterDetail>> ElementsMastersDetailsChanged { get; set; }
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
            SelectedMaster = new();

            model.CreateMasterRelations(SelectedMaster, SelectedDetail);

            var result = await OnShowDialogMaster(model);
            if (!result.Cancelled)
            {
                if (result.Data is TMaster)
                {
                    var resultmodel = result.Data as TMaster;


                    await OnRowClickedMaster.InvokeAsync(resultmodel);
                }

            }


        }
        async void AddDetail()
        {
            TMasterDetail model = new();

            SelectedDetail = new();
            model.CreateMasterRelations(SelectedMaster, SelectedDetail);

            var result = await OnShowDialogDetails(model);
            if (!result.Cancelled)
            {
                if (result.Data is TDetail)
                {
                    var resultmodel = result.Data as TDetail;


                    await OnRowClickedDetails.InvokeAsync(resultmodel);
                }

            }

        }

        async void EditMaster()
        {


            TMasterDetail model = new();
            model.CreateMasterRelations(SelectedMaster, SelectedDetail);


            var result = await OnShowDialogMaster(model);
            if (!result.Cancelled)
            {
                if (result.Data is TMaster)
                {
                    var resultmodel = result.Data as TMaster;


                    await OnRowClickedMaster.InvokeAsync(resultmodel);
                }

            }

        }
        async void EditDetails()
        {


            TMasterDetail model = new();
            model.CreateMasterRelations(SelectedMaster, SelectedDetail);
            var result = await OnShowDialogDetails(model);
            if (!result.Cancelled)
            {
                if (result.Data is TDetail)
                {
                    var resultmodel = result.Data as TDetail;


                    await OnRowClickedDetails.InvokeAsync(resultmodel);
                }

            }

        }
        async Task DeleteMaster()
        {
            TDeleteMaster ModelDelete = new() { Id = SelectedMaster.Id, Name = SelectedMaster.Name };

            var result = await ToolDialogService.DeleteRow(ModelDelete);

            if (!result.Cancelled)
            {
                TMaster model = new();
                ElementsMastersDetails = await mediator.Send(MasterDetailList) as List<TMasterDetail>;

                await ElementsMastersDetailsChanged.InvokeAsync(ElementsMastersDetails);

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
                ElementsMastersDetails = await mediator.Send(MasterDetailList) as List<TMasterDetail>;

                await ElementsMastersDetailsChanged.InvokeAsync(ElementsMastersDetails);

                await OnRowClickedDetails.InvokeAsync(model);
            }


        }
    }
}
