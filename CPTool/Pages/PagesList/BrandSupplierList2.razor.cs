

namespace CPTool.Pages.PagesList
{
    //public partial class BrandSupplierList : CancellableComponent, IDisposable

    //{
    //    [Inject]
    //    public IDTOManager<SupplierDTO,Supplier> ManagerSuppliers { get; set; }
    //    [Inject]
    //    public IDTOManager<BrandDTO, Brand> ManagerBrands { get; set; }
    //    [Inject]
    //    public IDTOManager<BrandSupplierDTO, BrandSupplier> ManagerBrandSupplier { get; set; }
    //    [Inject]
    //    public IGetList<SupplierDTO, Supplier> GetSuppliersList { get; set; }
    //    [Inject]
    //    public IGetList<BrandDTO, Brand> GetBrandsList { get; set; }
    //    [Inject]
    //    public IGetList<BrandSupplierDTO, BrandSupplier> GetBrandSupplierList { get; set; }
    //    [Parameter]
    //    public string MasterTableName { get; set; }
    //    [Parameter]
    //    public string DetailTableName { get; set; }
    //    [Parameter]
    //    public Func<BrandSupplierDTO, Task<DialogResult>> OnShowDialogMaster { get; set; }
    //    [Parameter]
    //    public Func<BrandSupplierDTO, Task<DialogResult>> OnShowDialogDetail { get; set; }
    //    BrandDTO SelectedMaster = new();

    //    SupplierDTO SelectedDetail = new();
    //    List<SupplierDTO> Details
    //        => SelectedMaster.Id == 0 ? TablesService.Suppliers : SelectedMaster.BrandSuppliersDTO.Select(
    //            x => TablesService.Suppliers.FirstOrDefault(y => y.Id == x.SupplierDTO.Id)).ToList();

    //    List<BrandDTO> Masters
    //    => SelectedDetail.Id == 0 ? TablesService.Brands : SelectedDetail.BrandSuppliersDTO.Select(
    //            x => TablesService.Brands.FirstOrDefault(y => y.Id == x.BrandDTO.Id)).ToList();


       

    //    void ViewMasterList()
    //    {
    //        SelectedMaster = new();

    //        SelectedDetail = new();
    //    }

    //    string PageTitle => $"Relation {MasterTableName} => {DetailTableName}";
    //    int mastersm => 6;
    //    int detailsm => 6;
    //    protected override void OnInitialized()
    //    {

            
    //    }
    //    void RowMasterClicked(BrandDTO dto)
    //    {
    //        SelectedMaster = dto;
    //        //SelectedDetail = new();

    //    }

    //    void RowDetailClicked(SupplierDTO dto)
    //    {
    //        //SelectedMaster = new();
    //        SelectedDetail = dto;

    //    }

    //    async Task<DialogResult> ShowDialogMaster(BrandDTO dto)
    //    {
    //        SelectedMaster = dto;
    //        BrandSupplierDTO bs = new();
    //        bs.BrandDTO = SelectedMaster;
    //        bs.SupplierDTO = SelectedDetail;
           
    //        var result = OnShowDialogMaster == null ? await ToolDialogService.ShowDialogName<BrandDTO>(dto) : await OnShowDialogMaster.Invoke(bs);
    //        if (!result.Cancelled)
    //        {
    //            bs = result.Data as BrandSupplierDTO;
    //            if(bs.BrandId!=0&&bs.SupplierId!=0)
    //            {
    //                var result2 = await ManagerBrandSupplier.AddUpdate(bs, _cts.Token);
                   
    //            }
    //            else
    //            {
    //                var result2 = await ManagerBrands.AddUpdate(bs.BrandDTO, _cts.Token);
    //            }
    //            TablesService.Brands = await GetBrandsList.Handle();
    //            TablesService.BrandSuppliers = await GetBrandSupplierList.Handle();
    //            StateHasChanged();
    //        }
    //        return result;
    //    }

    //    async Task<DialogResult> ShowDialogDetail(SupplierDTO dto)
    //    {

    //        SelectedDetail = dto;
    //        BrandSupplierDTO bs = new();
    //        bs.BrandDTO = SelectedMaster;
    //        bs.SupplierDTO = SelectedDetail;
           

    //        var result= OnShowDialogDetail == null ? await ToolDialogService.ShowDialogName<SupplierDTO>(dto) : await OnShowDialogDetail.Invoke(bs);

    //        if(!result.Cancelled)
    //        {

    //        }
           

    //        return result;
    //    }


    //    async Task<IResult<IAuditableEntityDTO>> SaveBrand(IAuditableEntityDTO dto)
    //    {
    //        var BrandSupplier = dto as BrandSupplierDTO;

    //        var result = await ManagerBrands.AddUpdate(BrandSupplier.BrandDTO, _cts.Token);
    //        if (result.Succeeded)
    //        {
    //            //BrandSupplier.BrandDTO = result.Data as BrandDTO;
    //            SelectedDetail = new();
    //            SelectedMaster = new();
               
    //            if (BrandSupplier.BrandId != 0 && BrandSupplier.SupplierId != 0)
    //            {
    //                var result2 = await ManagerBrandSupplier.AddUpdate(BrandSupplier, _cts.Token);
    //                if (result2.Succeeded)
    //                {

    //                    TablesService.BrandSuppliers = await GetBrandSupplierList.Handle();
    //                    TablesService.Suppliers= await GetSuppliersList.Handle();
    //                    SelectedDetail = await ManagerSuppliers.GetById(BrandSupplier.SupplierDTO.Id);
    //                }

    //            }
    //            TablesService.Brands = await GetBrandsList.Handle();

    //        }

    //        StateHasChanged();
          
    //        return await Result<AuditableEntityDTO>.SuccessAsync(new(), "Updated");
    //    }
    //    async Task<IResult<IAuditableEntityDTO>> SaveSupplier(IAuditableEntityDTO dto)
    //    {
    //        var BrandSupplier = dto as BrandSupplierDTO;
         
    //        var result = await ManagerSuppliers.AddUpdate(BrandSupplier.SupplierDTO, _cts.Token);
    //        if (result.Succeeded)
    //        {
    //            //BrandSupplier.SupplierDTO = result.Data as SupplierDTO;
    //            SelectedDetail = new();
    //            SelectedMaster = new();
              

    //            if (BrandSupplier.BrandId != 0 && BrandSupplier.SupplierId != 0)
    //            {
    //                var result2 = await ManagerBrandSupplier.AddUpdate(BrandSupplier, _cts.Token);
    //                if (result2.Succeeded)
    //                {
    //                    TablesService.BrandSuppliers = await GetBrandSupplierList.Handle();
    //                    TablesService.Brands = await GetBrandsList.Handle();

    //                    SelectedMaster = await ManagerBrands.GetById(BrandSupplier.BrandDTO.Id);
    //                }
    //            }
    //            TablesService.Suppliers = await GetSuppliersList.Handle();


    //        }
    //        StateHasChanged();

         

    //        return await Result<AuditableEntityDTO>.SuccessAsync(new(), "Updated");
    //    }
    //    async Task<IResult<IAuditableEntityDTO>> SaveBrandSupplier(IAuditableEntityDTO dto)
    //    {
    //        var BrandSupplier = dto as BrandSupplierDTO;
    //        if (BrandSupplier.BrandId != 0 && BrandSupplier.SupplierId != 0)
    //        {
    //            var result = await ManagerBrandSupplier.AddUpdate(BrandSupplier, _cts.Token);
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
    //        if (dto is BrandDTO)
    //        {
    //            result = await ManagerBrands.Delete(dto as BrandDTO, _cts.Token);
    //            if (result.Succeeded)
    //            {
    //                TablesService.Suppliers = await GetSuppliersList.Handle();
    //                TablesService.BrandSuppliers = await GetBrandSupplierList.Handle();
    //                TablesService.Brands = await GetBrandsList.Handle();
    //                StateHasChanged();
    //            }
    //            return result;
    //        }
    //        else if (dto is SupplierDTO)
    //        {
    //            result = await ManagerSuppliers.Delete(dto as SupplierDTO, _cts.Token);
    //            if (result.Succeeded)
    //            {
    //                TablesService.Suppliers = await GetSuppliersList.Handle();
    //                TablesService.BrandSuppliers = await GetBrandSupplierList.Handle();
    //                TablesService.Brands = await GetBrandsList.Handle();
    //                StateHasChanged();
    //            }
    //            return result;
    //        }

    //        return result;

    //    }
       
    //}
}