
using CPTool.Domain.Entities;

using static MudBlazor.Icons.Custom;


namespace CPTool.Pages.PagesList
{
    //public partial class PurchaseOrderMWOItemList : CancellableComponent

    //{
    //    [Inject]
    //    public IDTOManager<MWOItemDTO, MWOItem> ManagerMWOItem { get; set; }
    //    [Inject]
    //    public IDTOManager<PurchaseOrderDTO, PurchaseOrder> ManagerPurchaseOrder { get; set; }
    //    [Inject]
    //    public IDTOManager<PurchaseOrderMWOItemDTO, PurchaseOrderMWOItem> ManagerPurchaseOrderMWOItem { get; set; }
    //    [Inject]
    //    public IGetList<MWOItemDTO, MWOItem> GetMWOItemList { get; set; }
    //    [Inject]
    //    public IGetList<PurchaseOrderDTO, PurchaseOrder> GetPurchaseOrderList { get; set; }
    //    [Inject]
    //    public IGetList<PurchaseOrderMWOItemDTO, PurchaseOrderMWOItem> GetPurchaseOrderMWOItemList { get; set; }
    //    [Parameter]
    //    public bool ShowAddButton { get; set; } = false;

    //    [Parameter]
    //    public string MasterTableName { get; set; }
    //    [Parameter]
    //    public string DetailTableName { get; set; }
    //    [Parameter]
    //    public Func<PurchaseOrderMWOItemDTO, Task<DialogResult>> OnShowDialogMaster { get; set; }
    //    [Parameter]
    //    public Func<PurchaseOrderMWOItemDTO, Task<DialogResult>> OnShowDialogDetail { get; set; }
    //    PurchaseOrderDTO SelectedMaster = new();

    //    MWOItemDTO SelectedDetail = new();
    //    List<MWOItemDTO> Details = new();

    //    List<PurchaseOrderDTO> Masters => TablesService.PurchaseOrders.Count == 0 ? new() : TablesService.PurchaseOrders.OrderBy(x => (int)x.PurchaseOrderStatus).ToList();

    //    Func<PurchaseOrderDTO, string, bool> SearchMaster => (PurchaseOrderDTO element, string searchString) => OnfuncSearchMaster(element, searchString);

    //    bool OnfuncSearchMaster(PurchaseOrderDTO element, string searchString)
    //    {
    //        var retorno = element.PurchaseRequisition.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
    //        element.PONumber.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
    //        element.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
    //        element.MWOItemDTO.MWODTO.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
    //        element.MWOItemDTO.MWODTO.CECName.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
    //        element.PurchaseOrderStatus.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
    //        element.SupplierDTO.Name.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
    //        element.BrandDTO.Name.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase);
    //        return retorno;
    //    }
    //    void ViewMasterList()
    //    {
    //        SelectedMaster = new();
    //        bool encontrado = Masters.Any(x => x.PurchaseRequisition.Contains(value));

    //        SelectedDetail = new();
    //    }
    //    async Task AddDownPayment()
    //    {
    //        DownPaymentDTO model = new();
    //        model.PurchaseOrderDTO = SelectedMaster;


    //        var retorno = await ToolDialogService.ShowDownpaymentDialog(model);
    //    }
    //    string PageTitle => $"Relation {MasterTableName} => {DetailTableName}";

    //    protected override void OnInitialized()
    //    {


    //    }
    //    void RowMasterClicked(PurchaseOrderDTO dto)
    //    {
    //        SelectedMaster = dto;
    //        //SelectedDetail = new();

    //    }

    //    void RowDetailClicked(MWOItemDTO dto)
    //    {
    //        //SelectedMaster = new();
    //        SelectedDetail = dto;

    //    }

    //    async Task<DialogResult> ShowDialogMaster(PurchaseOrderDTO dto)
    //    {
    //        SelectedMaster = dto;
    //        PurchaseOrderMWOItemDTO bs = new();
    //        bs.PurchaseOrderDTO = SelectedMaster;
    //        SelectedDetail = bs.PurchaseOrderDTO.PurchaseOrderMWOItemsDTO.FirstOrDefault().MWOItemDTO;
    //        bs.MWOItemDTO = SelectedDetail;



    //        bs.PurchaseOrderCreated = true;

    //        var result = OnShowDialogMaster == null ? await ToolDialogService.ShowDialogName<PurchaseOrderDTO>(dto) : await OnShowDialogMaster.Invoke(bs);


    //        return result;


    //    }

    //    async Task<DialogResult> ShowDialogDetail(MWOItemDTO dto)
    //    {

    //        SelectedDetail = dto;
    //        PurchaseOrderMWOItemDTO bs = new();
    //        bs.PurchaseOrderDTO = SelectedMaster;
    //        bs.MWOItemDTO = SelectedDetail;



    //        var result = OnShowDialogDetail == null ? await ToolDialogService.ShowDialogName<MWOItemDTO>(dto) : await OnShowDialogDetail.Invoke(bs);
           
    //        return result;


    //    }


    //    async Task<IResult<IAuditableEntityDTO>> SaveMaster(IAuditableEntityDTO dto)
    //    {
    //        var purchaseOrderMWOItemDTO = dto as PurchaseOrderMWOItemDTO;

    //        var result = await ManagerPurchaseOrder.AddUpdate(purchaseOrderMWOItemDTO.PurchaseOrderDTO, _cts.Token);
    //        if (result.Succeeded)
    //        {
    //            //purchaseOrderMWOItemDTO.PurchaseOrderDTO = result.Data as PurchaseOrderDTO;
    //            SelectedDetail = new();
    //            SelectedMaster = new();

    //            if (purchaseOrderMWOItemDTO.PurchaseOrderDTOId != 0 && purchaseOrderMWOItemDTO.MWOItemDTOId != 0)
    //            {
    //                var result2 = await ManagerPurchaseOrderMWOItem.AddUpdate(purchaseOrderMWOItemDTO, _cts.Token);
    //                if (result2.Succeeded)
    //                {
                        
    //                    TablesService.MWOItems = await GetMWOItemList.Handle();
                    
    //                    SelectedDetail = await ManagerMWOItem.GetById(purchaseOrderMWOItemDTO.MWOItemDTOId);
    //                }

    //            }
    //            TablesService.PurchaseOrders = await GetPurchaseOrderList.Handle();

    //        }

    //        StateHasChanged();

    //        return await Result<AuditableEntityDTO>.SuccessAsync(new(), "Updated");
    //    }
    //    async Task<IResult<IAuditableEntityDTO>> SaveDetail(IAuditableEntityDTO dto)
    //    {
    //        var purchaseOrderMWOItemDTO = dto as PurchaseOrderMWOItemDTO;

    //        var result = await ManagerMWOItem.AddUpdate(purchaseOrderMWOItemDTO.MWOItemDTO, _cts.Token);
    //        if (result.Succeeded)
    //        {
    //            //purchaseOrderMWOItemDTO.MWOItemDTO = result.Data as MWOItemDTO;
    //            SelectedDetail = new();
    //            SelectedMaster = new();


    //            if (purchaseOrderMWOItemDTO.PurchaseOrderDTOId != 0 && purchaseOrderMWOItemDTO.MWOItemDTOId != 0)
    //            {
    //                var result2 = await ManagerPurchaseOrderMWOItem.AddUpdate(purchaseOrderMWOItemDTO, _cts.Token);
    //                if (result2.Succeeded)
    //                {
    //                    TablesService.PurchaseOrders = await GetPurchaseOrderList.Handle();

    //                    SelectedMaster = await ManagerPurchaseOrder.GetById(purchaseOrderMWOItemDTO.PurchaseOrderDTOId);
    //                }
    //            }
               
    //            TablesService.MWOItems = await GetMWOItemList.Handle();

    //        }
    //        StateHasChanged();



    //        return await Result<AuditableEntityDTO>.SuccessAsync(new(), "Updated");
    //    }
    //    async Task<IResult<IAuditableEntityDTO>> SaveBrandSupplier(IAuditableEntityDTO dto)
    //    {
    //        var purchaseOrderMWOItemDTO = dto as PurchaseOrderMWOItemDTO;
    //        if (purchaseOrderMWOItemDTO.PurchaseOrderDTOId != 0 && purchaseOrderMWOItemDTO.MWOItemDTOId != 0)
    //        {
    //            var result = await ManagerPurchaseOrderMWOItem.AddUpdate(purchaseOrderMWOItemDTO, _cts.Token);
    //            if (result.Succeeded)
    //            {

    //                //return await Result<IAuditableEntityDTO>.SuccessAsync(result.Data, "Updated");
    //            }

    //        }

    //        return await Result<IAuditableEntityDTO>.SuccessAsync(dto, "Not Updated");

    //    }
    //    async Task<IResult> Delete(IAuditableEntityDTO dto)
    //    {
    //        IResult result = null;
    //        if (dto is PurchaseOrderDTO)
    //        {
    //            result = await ManagerPurchaseOrder.Delete(dto as PurchaseOrderDTO, _cts.Token);
    //            if (result.Succeeded)
    //            {
    //                TablesService.PurchaseOrderMWOItems = await GetPurchaseOrderMWOItemList.Handle();
    //                TablesService.PurchaseOrders = await GetPurchaseOrderList.Handle();
    //                TablesService.MWOItems = await GetMWOItemList.Handle();
                   
    //                StateHasChanged();
    //            }
    //            return result;
    //        }
    //        else if (dto is MWOItemDTO)
    //        {
    //            result = await ManagerMWOItem.Delete(dto as MWOItemDTO, _cts.Token);
    //            if (result.Succeeded)
    //            {
    //                TablesService.PurchaseOrderMWOItems = await GetPurchaseOrderMWOItemList.Handle();
    //                TablesService.PurchaseOrders = await GetPurchaseOrderList.Handle();
    //                TablesService.MWOItems = await GetMWOItemList.Handle();
    //                StateHasChanged();
    //            }
    //            return result;
    //        }

    //        return result;

    //    }

    //}
}