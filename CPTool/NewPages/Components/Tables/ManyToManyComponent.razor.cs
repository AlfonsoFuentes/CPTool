
using CPtool.ExtensionMethods;
using CPTool.Application.Features.Base;
using CPTool.Application.Features.Base.Delete;
using CPTool.Application.Features.BrandFeatures.CreateEdit;
using CPTool.Application.Features.BrandFeatures.Query.GetById;
using CPTool.Application.Features.SupplierFeatures.CreateEdit;
using CPTool.Application.Features.SupplierFeatures.Query.GetById;
using CPTool.Domain.Entities;
using MediatR;
using MudBlazor;
using static MudBlazor.Icons.Custom;

namespace CPTool.NewPages.Components.Tables
{
    public partial class ManyToManyComponent<TMasterDetail, TMaster, TDetail, TManagerMasterDetail, TManagerMaster, TManagerDetail>
         where TMasterDetail : EditCommand, new()
        where TMaster : EditCommand, new()
        where TDetail : EditCommand, new()

         where TManagerMasterDetail : Manager, new()
        where TManagerMaster : Manager, new()
        where TManagerDetail : Manager, new()

    {

        TManagerMasterDetail MasterDetailManager = new();
        TManagerMaster MasterManager = new(); 
        TManagerDetail DetailManager = new ();

        [Parameter]
        [Category("Footer")]
        public RenderFragment FooterContentDetails { get; set; }
        [Parameter]
        [Category("Footer")]
        public RenderFragment FooterContentMaster { get; set; }
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
        public EventCallback OnAddMaster { get; set; }

        [Parameter]
        public EventCallback OnEditMaster { get; set; }

        [Parameter]
        public EventCallback OnDeleteMaster { get; set; }

        [Parameter]
        public EventCallback OnAddDetail { get; set; }

        [Parameter]
        public EventCallback OnEditDetail { get; set; }

        [Parameter]
        public EventCallback OnDeleteDetail { get; set; }
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
        public Func<TMasterDetail, Task<DialogResult>> OnShowDialogMaster { get; set; }
        [Parameter]       
        public Func<TMasterDetail, Task<DialogResult>> OnShowDialogDetails { get; set; }
        
        async Task RowClickedMaster(TableRowClickEventArgs<TMaster> row)
        {
            SelectedMaster = row.Item;
            await SelectedMasterChanged.InvokeAsync(SelectedMaster);
        }
        async Task RowClickedDetails(TableRowClickEventArgs<TDetail> row)
        {
            SelectedDetail = row.Item;
            await SelectedDetailChanged.InvokeAsync(SelectedDetail);
        }
        async Task AddMaster()
        {
            if (OnAddMaster.HasDelegate)  await OnAddMaster.InvokeAsync();
            else
            {
                TMasterDetail model = new();
                SelectedMaster = new();

                model.CreateMasterRelations(SelectedMaster, SelectedDetail);

                var result = await OnShowDialogMaster(model);
                if (!result.Cancelled)
                {
                    SelectedMaster = result.Data as TMaster;

                    await UpdateTables();

                }
            }
            


        }
        async void EditMaster()
        {

            if (OnEditMaster.HasDelegate) await OnEditMaster.InvokeAsync();
            else
            {
                TMasterDetail model = new();

                model.SetMaster(SelectedMaster, SelectedDetail);


                var result = await OnShowDialogMaster(model);
                if (!result.Cancelled)
                {
                 
                    SelectedMaster = result.Data as TMaster;

                    await UpdateTables();
                }
            }

        }
        async Task DeleteMaster()
        {
            if (OnDeleteMaster.HasDelegate) await OnDeleteMaster.InvokeAsync();
            else
            {

                MasterManager.DeleteCommand = new() { Id = SelectedMaster.Id, Name = SelectedMaster.Name };

                var result = await ToolDialogService.DeleteRow(MasterManager.DeleteCommand);

                if (!result.Cancelled)
                {
                    SelectedMaster = new();
                  
                    await UpdateTables();
                }
            }

        }
       
        async void AddDetail()
        {
            if (OnAddDetail.HasDelegate) await OnAddDetail.InvokeAsync();
            else
            {
                TMasterDetail model = new();

                SelectedDetail = new();
                model.CreateMasterRelations(SelectedMaster, SelectedDetail);

                var result = await OnShowDialogDetails(model);
                if (!result.Cancelled)
                {
                    SelectedDetail = result.Data as TDetail;
                    await UpdateTables();


                }
            }

        }
       
        async void EditDetails()
        {

            if (OnEditDetail.HasDelegate) await OnEditDetail.InvokeAsync();
            else
            {
                TMasterDetail model = new();
                model.SetDetail(SelectedDetail, SelectedMaster);
                var result = await OnShowDialogDetails(model);
                if (!result.Cancelled)
                {

                    SelectedDetail = result.Data as TDetail;
                    await UpdateTables();
                }
            }

        }

        async Task DeleteDetails()
        {
            if (OnDeleteDetail.HasDelegate) await OnDeleteDetail.InvokeAsync();
            else
            {
                DetailManager.DeleteCommand = new() { Id = SelectedDetail.Id, Name = SelectedDetail.Name };

                var result = await ToolDialogService.DeleteRow(DetailManager.DeleteCommand);

                if (!result.Cancelled)
                {
                    SelectedDetail = new();
                    await UpdateTables();
                }
            }

        }
       
        async Task UpdateTables()
        {
            ElementsMastersDetails = await Mediator.Send(MasterDetailManager.GetListQuery) as List<TMasterDetail>;
            await ElementsMastersDetailsChanged.InvokeAsync(ElementsMastersDetails);

            ElementsDetails = await Mediator.Send(DetailManager.GetListQuery) as List<TDetail>;
            await ElementsDetailsChanged.InvokeAsync(ElementsDetails);

            ElementsMasters = await Mediator.Send(MasterManager.GetListQuery) as List<TMaster>;
            await ElementsMastersChanged.InvokeAsync(ElementsMasters);

            MasterManager.GetByIdQuery.Id = SelectedMaster.Id;
            SelectedMaster = (await Mediator.Send(MasterManager.GetByIdQuery)) as TMaster;
            await SelectedMasterChanged.InvokeAsync(SelectedMaster);

            DetailManager.GetByIdQuery.Id = SelectedDetail.Id;
            SelectedDetail = (await Mediator.Send(DetailManager.GetByIdQuery)) as TDetail;
            await SelectedDetailChanged.InvokeAsync(SelectedDetail);
        }

    }
}
