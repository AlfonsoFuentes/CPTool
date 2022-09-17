using CPTool.Entities;
using CPTool.Implementations;
using static MudBlazor.Icons.Custom;

namespace CPTool.Pages.ManytoManyList
{
    public partial class PurchaseOrderMWOItemList : CancellableComponent, IDisposable

    {
        [Parameter]
        public bool ShowAddButton { get; set; } = false;

        [Parameter]
        public string MasterTableName { get; set; }
        [Parameter]
        public string DetailTableName { get; set; }
        [Parameter]
        public Func<PurchaseOrderMWOItemDTO, Task<DialogResult>> OnShowDialogMaster { get; set; }
        [Parameter]
        public Func<PurchaseOrderMWOItemDTO, Task<DialogResult>> OnShowDialogDetail { get; set; }
        PurchaseOrderDTO SelectedMaster = new();

        MWOItemDTO SelectedDetail = new();
        List<MWOItemDTO> Details
            => SelectedMaster.Id == 0 ? new() : SelectedMaster.PurchaseOrderMWOItemDTOs.Select(
                x => TablesService.ManMWOItem.List.FirstOrDefault(y => y.Id == x.MWOItemDTO.Id)).ToList();

        List<PurchaseOrderDTO> Masters => TablesService.ManPurchaseOrder.List.OrderBy(x => (int)x.PurchaseOrderStatus).ToList();

        Func<PurchaseOrderDTO,string, bool> SearchMaster => (PurchaseOrderDTO element,string searchString) => OnfuncSearchMaster(element, searchString);

        bool OnfuncSearchMaster(PurchaseOrderDTO element,string searchString)
        {
            var retorno= element.PurchaseRequisition.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
            element.PONumber.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
            element.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
            element.PurchaseOrderStatus.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase);
            return retorno;
        }
        void ViewMasterList()
        {
            SelectedMaster = new();
            bool encontrado = Masters.Any(x => x.PurchaseRequisition.Contains(value));

            SelectedDetail = new();
        }
        async Task AddDownPayment()
        {
            DownPaymentDTO model = new();
            model.PurchaseOrderDTO = SelectedMaster;
           

            var retorno = await ToolDialogService.ShowDownpaymentDialog(model);
        }
        string PageTitle => $"Relation {MasterTableName} => {DetailTableName}";
        int mastersm => 6;
        int detailsm => 6;
        protected override void OnInitialized()
        {

            TablesService.Delete += Delete;
        }
        void RowMasterClicked(PurchaseOrderDTO dto)
        {
            SelectedMaster = dto;
            //SelectedDetail = new();

        }

        void RowDetailClicked(MWOItemDTO dto)
        {
            //SelectedMaster = new();
            SelectedDetail = dto;

        }

        async Task<DialogResult> ShowDialogMaster(PurchaseOrderDTO dto)
        {
            SelectedMaster = dto;
            PurchaseOrderMWOItemDTO bs = new();
            bs.PurchaseOrderDTO = SelectedMaster;
            SelectedDetail = bs.PurchaseOrderDTO.PurchaseOrderMWOItemDTOs.FirstOrDefault().MWOItemDTO;
            bs.MWOItemDTO = SelectedDetail;

          
            TablesService.Save += SaveMaster;
            bs.PurchaseOrderCreated = true;

            var result = OnShowDialogMaster == null ? await ToolDialogService.ShowDialogName<PurchaseOrderDTO>(dto) : await OnShowDialogMaster.Invoke(bs);

            if (result.Cancelled) TablesService.Save -= SaveMaster;
            return result;


        }

        async Task<DialogResult> ShowDialogDetail(MWOItemDTO dto)
        {

            SelectedDetail = dto;
            PurchaseOrderMWOItemDTO bs = new();
            bs.PurchaseOrderDTO = SelectedMaster;
            bs.MWOItemDTO = SelectedDetail;

            TablesService.Save += SaveDetail;

            var result = OnShowDialogDetail == null ? await ToolDialogService.ShowDialogName<MWOItemDTO>(dto) : await OnShowDialogDetail.Invoke(bs);
            if (result.Cancelled) TablesService.Save -= SaveDetail;
            return result;


        }


        async Task<IResult<IAuditableEntityDTO>> SaveMaster(IAuditableEntityDTO dto)
        {
            var purchaseOrderMWOItemDTO = dto as PurchaseOrderMWOItemDTO;

            var result = await TablesService.ManPurchaseOrder.AddUpdate(purchaseOrderMWOItemDTO.PurchaseOrderDTO, _cts.Token);
            if (result.Succeeded)
            {
                purchaseOrderMWOItemDTO.PurchaseOrderDTO = result.Data;
                SelectedDetail = new();
                SelectedMaster = new();

                if (purchaseOrderMWOItemDTO.PurchaseOrderId != 0 && purchaseOrderMWOItemDTO.MWOItemId != 0)
                {
                    var result2 = await TablesService.ManPurchaseOrderMWOItem.AddUpdate(purchaseOrderMWOItemDTO, _cts.Token);
                    if (result2.Succeeded)
                    {
                        await TablesService.ManPurchaseOrderMWOItem.UpdateList();

                        await TablesService.ManMWOItem.UpdateList();
                        SelectedDetail = (await TablesService.ManMWOItem.GetById(purchaseOrderMWOItemDTO.MWOItemDTO.Id)).Data;
                    }

                }
                await TablesService.ManPurchaseOrder.UpdateList();

            }

            StateHasChanged();
            TablesService.Save -= SaveMaster;
            return await Result<AuditableEntityDTO>.SuccessAsync(new(), "Updated");
        }
        async Task<IResult<IAuditableEntityDTO>> SaveDetail(IAuditableEntityDTO dto)
        {
            var purchaseOrderMWOItemDTO = dto as PurchaseOrderMWOItemDTO;

            var result = await TablesService.ManMWOItem.AddUpdate(purchaseOrderMWOItemDTO.MWOItemDTO, _cts.Token);
            if (result.Succeeded)
            {
                purchaseOrderMWOItemDTO.MWOItemDTO = result.Data;
                SelectedDetail = new();
                SelectedMaster = new();


                if (purchaseOrderMWOItemDTO.PurchaseOrderId != 0 && purchaseOrderMWOItemDTO.MWOItemId != 0)
                {
                    var result2 = await TablesService.ManPurchaseOrderMWOItem.AddUpdate(purchaseOrderMWOItemDTO, _cts.Token);
                    if (result2.Succeeded)
                    {
                        await TablesService.ManPurchaseOrderMWOItem.UpdateList();
                        await TablesService.ManPurchaseOrder.UpdateList();

                        SelectedMaster = (await TablesService.ManPurchaseOrder.GetById(purchaseOrderMWOItemDTO.PurchaseOrderDTO.Id)).Data;
                    }
                }
                await TablesService.ManMWOItem.UpdateList();


            }
            StateHasChanged();

            TablesService.Save -= SaveDetail;

            return await Result<AuditableEntityDTO>.SuccessAsync(new(), "Updated");
        }
        async Task<IResult<IAuditableEntityDTO>> SaveBrandSupplier(IAuditableEntityDTO dto)
        {
            var purchaseOrderMWOItemDTO = dto as PurchaseOrderMWOItemDTO;
            if (purchaseOrderMWOItemDTO.PurchaseOrderId != 0 && purchaseOrderMWOItemDTO.MWOItemId != 0)
            {
                var result = await TablesService.ManPurchaseOrderMWOItem.AddUpdate(dto, _cts.Token);
                if (result.Succeeded)
                {

                    return await Result<IAuditableEntityDTO>.SuccessAsync(result.Data, "Updated");
                }

            }

            return await Result<IAuditableEntityDTO>.SuccessAsync(dto, "Not Updated");

        }
        async Task<IResult<int>> Delete(IAuditableEntityDTO dto)
        {
            IResult<int> result = null;
            if (dto is PurchaseOrderDTO)
            {
                result = await TablesService.ManPurchaseOrder.Delete(dto.Id, _cts.Token);
                if (result.Succeeded)
                {
                    await TablesService.ManMWOItem.UpdateList();
                    await TablesService.ManPurchaseOrderMWOItem.UpdateList();
                    await TablesService.ManPurchaseOrder.UpdateList();
                    StateHasChanged();
                }
                return result;
            }
            else if (dto is MWOItemDTO)
            {
                result = await TablesService.ManMWOItem.Delete(dto.Id, _cts.Token);
                if (result.Succeeded)
                {
                    await TablesService.ManMWOItem.UpdateList();
                    await TablesService.ManPurchaseOrderMWOItem.UpdateList();
                    await TablesService.ManPurchaseOrder.UpdateList();
                    StateHasChanged();
                }
                return result;
            }

            return result;

        }
        void IDisposable.Dispose()
        {


            TablesService.Delete -= Delete;
        }
    }
}