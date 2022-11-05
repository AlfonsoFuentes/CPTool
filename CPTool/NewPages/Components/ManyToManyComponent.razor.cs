
using CPtool.ExtensionMethods;
using CPTool.Application.Features.Base.Delete;
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
        [EditorRequired]
        public List<TMaster> ElementsMastersSelected { get; set; } = new();
        [Parameter]
        public EventCallback<List<TMaster>> ElementsMastersChanged { get; set; }
        [Parameter]
        public List<TDetail> ElementsDetails { get; set; } = new();
        [Parameter]
        [EditorRequired]
        public List<TDetail> ElementsDetailsSelected { get; set; } = new();
        [Parameter]
        public EventCallback<List<TDetail>> ElementsDetailsChanged { get; set; }
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
        public Func<TMasterDetail, Task<DialogResult>> OnShowDialogMaster { get; set; }
        [Parameter]
        [EditorRequired]
        public Func<TMasterDetail, Task<DialogResult>> OnShowDialogDetails { get; set; }



        async Task RowClickedMaster(TableRowClickEventArgs<TMaster> row)
        {
            SelectedMaster = row.Item;
            await SelectedMasterChanged.InvokeAsync(row.Item);
        }
        async Task RowClickedDetails(TableRowClickEventArgs<TDetail> row)
        {
            SelectedDetail=row.Item;    
            await SelectedDetailChanged.InvokeAsync(row.Item);
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
                    ElementsMastersDetails = await Mediator.Send(MasterDetailList) as List<TMasterDetail>;
                    await ElementsMastersDetailsChanged.InvokeAsync(ElementsMastersDetails);
                    ElementsMasters = await Mediator.Send(MasterList) as List<TMaster>;
                    await ElementsMastersChanged.InvokeAsync(ElementsMasters);
                    var resultmodel = result.Data as TMaster;
                    await SelectedMasterChanged.InvokeAsync(resultmodel);
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
                    ElementsMastersDetails = await Mediator.Send(MasterDetailList) as List<TMasterDetail>;
                    await ElementsMastersDetailsChanged.InvokeAsync(ElementsMastersDetails);
                    ElementsDetails = await Mediator.Send(DetailList) as List<TDetail>;
                    await ElementsDetailsChanged.InvokeAsync(ElementsDetails);

                    var resultmodel = result.Data as TDetail;
                    await SelectedDetailChanged.InvokeAsync(resultmodel);


                }

            }

        }

        async void EditMaster()
        {


            TMasterDetail model = new();

            model.SetMaster(SelectedMaster, SelectedDetail);


            var result = await OnShowDialogMaster(model);
            if (!result.Cancelled)
            {
                if (result.Data is TMaster)
                {
                    ElementsMastersDetails = await Mediator.Send(MasterDetailList) as List<TMasterDetail>;
                    await ElementsMastersDetailsChanged.InvokeAsync(ElementsMastersDetails);
                    ElementsMasters = await Mediator.Send(MasterList) as List<TMaster>;
                    await ElementsMastersChanged.InvokeAsync(ElementsMasters);
                    var resultmodel = result.Data as TMaster;
                    await SelectedMasterChanged.InvokeAsync(resultmodel);
                }

            }

        }
        async void EditDetails()
        {


            TMasterDetail model = new();
            model.SetDetail(SelectedDetail, SelectedMaster);
            var result = await OnShowDialogDetails(model);
            if (!result.Cancelled)
            {
                if (result.Data is TDetail)
                {
                    ElementsMastersDetails = await Mediator.Send(MasterDetailList) as List<TMasterDetail>;
                    await ElementsMastersDetailsChanged.InvokeAsync(ElementsMastersDetails);
                    ElementsDetails = await Mediator.Send(DetailList) as List<TDetail>;
                    await ElementsDetailsChanged.InvokeAsync(ElementsDetails);
                    var resultmodel = result.Data as TDetail;
                    await SelectedDetailChanged.InvokeAsync(resultmodel);
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
                ElementsMastersDetails = await Mediator.Send(MasterDetailList) as List<TMasterDetail>;

                await ElementsMastersDetailsChanged.InvokeAsync(ElementsMastersDetails);
                ElementsMasters = await Mediator.Send(MasterList) as List<TMaster>;
                await ElementsMastersChanged.InvokeAsync(ElementsMasters);
                await SelectedMasterChanged.InvokeAsync(model);
            }


        }
        async Task DeleteDetails()
        {
            TDeleteDetail ModelDelete = new() { Id = SelectedDetail.Id, Name = SelectedDetail.Name };

            var result = await ToolDialogService.DeleteRow(ModelDelete);

            if (!result.Cancelled)
            {
                TDetail model = new();
                ElementsMastersDetails = await Mediator.Send(MasterDetailList) as List<TMasterDetail>;

                await ElementsMastersDetailsChanged.InvokeAsync(ElementsMastersDetails);
                ElementsDetails = await Mediator.Send(DetailList) as List<TDetail>;
                await ElementsDetailsChanged.InvokeAsync(ElementsDetails);
                await SelectedDetailChanged.InvokeAsync(model);
            }


        }
    }
}
