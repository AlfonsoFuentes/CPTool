using CPTool.Entities;
using CPTool.Implementations;
using static MudBlazor.Icons.Custom;

namespace CPTool.Pages.BrandSupplierPages
{
    public partial class BrandSupplierList : CancellableComponent, IDisposable

    {

        [Parameter]
        public string MasterTableName { get; set; }
        [Parameter]
        public string DetailTableName { get; set; }
        [Parameter]
        public Func<BrandSupplierDTO, Task<DialogResult>> OnShowDialogMaster { get; set; }
        [Parameter]
        public Func<BrandSupplierDTO, Task<DialogResult>> OnShowDialogDetail { get; set; }
        BrandDTO SelectedMaster = new();

        SupplierDTO SelectedDetail = new();
        List<SupplierDTO> Details
            => SelectedMaster.Id == 0 ? TablesService.ManSupplier.List : SelectedMaster.BrandSupplierDTOs.Select(
                x => TablesService.ManSupplier.List.FirstOrDefault(y => y.Id == x.SupplierDTO.Id)).ToList();

        List<BrandDTO> Masters
        => SelectedDetail.Id == 0 ? TablesService.ManBrand.List : SelectedDetail.BrandSupplierDTOs.Select(
                x => TablesService.ManBrand.List.FirstOrDefault(y => y.Id == x.BrandDTO.Id)).ToList();


        ComponentTableList<BrandDTO, Brand> tableMaster;
        ComponentTableList<SupplierDTO, Supplier> tableDetail;

        void ViewMasterList()
        {
            SelectedMaster = new();

            SelectedDetail = new();
        }

        string PageTitle => $"Relation {MasterTableName} => {DetailTableName}";
        int mastersm => 6;
        int detailsm => 6;
        protected override void OnInitialized()
        {


           
            TablesService.Save += Save;
            TablesService.Delete += Delete;
        }
        void RowMasterClicked(BrandDTO dto)
        {
            SelectedMaster = dto;



        }

        void RowDetailClicked(SupplierDTO dto)
        {

            SelectedDetail = dto;

        }



        async Task<DialogResult> ShowDialogMaster(BrandDTO dto)
        {
            SelectedMaster = dto;
            BrandSupplierDTO bs = new();
            bs.BrandDTO = SelectedMaster;
            bs.SupplierDTO = SelectedDetail;
            //bs.BrandToRemoveId = SelectedMaster.Id;
            //bs.SupplierToRemoveId = SelectedDetail.Id;
            return OnShowDialogMaster == null ? await ToolDialogService.ShowDialogName<BrandDTO>(dto) : await OnShowDialogMaster.Invoke(bs);


        }

        async Task<DialogResult> ShowDialogDetail(SupplierDTO dto)
        {

            SelectedDetail = dto;
            BrandSupplierDTO bs = new();
            bs.BrandDTO = SelectedMaster;
            bs.SupplierDTO = SelectedDetail;
            //bs.BrandToRemoveId = SelectedMaster.Id;
            //bs.SupplierToRemoveId = SelectedDetail.Id;

            return OnShowDialogDetail == null ? await ToolDialogService.ShowDialogName<SupplierDTO>(dto) : await OnShowDialogDetail.Invoke(bs);


        }
        async Task AddBrand(BrandSupplierDTO convertedDTO)
        {
            var result = await TablesService.ManBrand.AddUpdate(convertedDTO.BrandDTO, _cts.Token);
            if (result.Succeeded)
            {
                convertedDTO.BrandDTO = result.Data;
               
                SelectedDetail = new();
             



            }
        }
        async Task AddSupplier(BrandSupplierDTO convertedDTO)
        {
            var result = await TablesService.ManSupplier.AddUpdate(convertedDTO.SupplierDTO, _cts.Token);
            if (result.Succeeded)
            {
                convertedDTO.SupplierDTO = result.Data;
                //await TablesService.ManSupplier.GetList();
                SelectedMaster = new();
               

            }
        }
        async Task RemoveBrandSupplier(BrandSupplierDTO convertedDTO)
        {
            //bool remove = false;
            //if (convertedDTO.BrandDTO.Id == 0 && convertedDTO.BrandToRemoveId != 0)
            //{
            //    remove = true;
            //}
            //if (convertedDTO.SupplierDTO.Id == 0 && convertedDTO.SupplierToRemoveId != 0)
            //{
            //    remove = true;
            //}
            //if (remove)
            //{
            //    if (TablesService.ManBrandSupplier.List.Any(x => x.BrandId == convertedDTO.BrandToRemoveId && x.SupplierId == convertedDTO.SupplierToRemoveId))
            //    {
            //        var brandsuplier = TablesService.ManBrandSupplier.List.FirstOrDefault(x =>
            //        x.BrandId == convertedDTO.BrandToRemoveId && x.SupplierId == convertedDTO.SupplierToRemoveId);
            //        if (brandsuplier != null)
            //        {
            //            await TablesService.ManBrandSupplier.Delete(brandsuplier.Id, _cts.Token);
            //            await TablesService.ManBrand.UpdateList();
            //            await TablesService.ManSupplier.UpdateList();
            //        }
            //    }
            //}
        }
        async Task<IResult<IAuditableEntityDTO>> AddBrandSupplier(BrandSupplierDTO convertedDTO)
        {
            IResult<IAuditableEntityDTO> result=null;
            //if (!TablesService.ManBrandSupplier.List.Any(x =>
            //x.BrandId == convertedDTO.BrandDTO.Id && x.SupplierId == convertedDTO.SupplierDTO.Id))
            //{
            //    var brandsupplier = new BrandSupplierDTO
            //    {
            //        BrandId = convertedDTO.BrandDTO.Id,
            //        SupplierId = convertedDTO.SupplierDTO.Id
            //    };
            //    result = await TablesService.ManBrandSupplier.AddUpdate(brandsupplier, _cts.Token);
            //    await TablesService.ManBrand.UpdateList();
            //    await TablesService.ManSupplier.UpdateList();
            //}
            //else
            //{
            //    result = await TablesService.ManBrandSupplier.AddUpdate(convertedDTO, _cts.Token);

            //}
            return result;
        }
        async Task<IResult<IAuditableEntityDTO>> Save(IAuditableEntityDTO dto)
        {


            //BrandSupplierDTO convertedDTO = dto as BrandSupplierDTO;

            //if (convertedDTO.BrandCreatedUpdate)
            //{
            //    await AddBrand(convertedDTO);
            //}
            //if (convertedDTO.SupplierCreatedUpdate)
            //{
            //    await AddSupplier(convertedDTO);
            //}
            //if (convertedDTO.BrandDTO.Id != 0 && convertedDTO.SupplierDTO.Id != 0)
            //{
            //   await AddBrandSupplier(convertedDTO);

            //}
            //else
            //{
            //    await RemoveBrandSupplier(convertedDTO);
            //}
            //SelectedDetail = new();
            //SelectedMaster = new();

            //StateHasChanged();


            return await Result<AuditableEntityDTO>.SuccessAsync(new(), "Updated");
        }
        
        async Task<IResult<int>> Delete(IAuditableEntityDTO dto)
        {
            IResult<int> result = null;
            if (dto is BrandDTO)
            {
                result = await TablesService.ManBrand.Delete(dto.Id, _cts.Token);
                if (result.Succeeded)
                {
                    //await TablesService.OnUpdateList();
                }
                return result;
            }
            else if (dto is SupplierDTO)
            {
                result = await TablesService.ManSupplier.Delete(dto.Id, _cts.Token);
                if (result.Succeeded)
                {
                    //await TablesService.OnUpdateList();
                }
                return result;
            }
            if (result.Succeeded)
            {
                //await TablesService.OnUpdateList();
            }
            StateHasChanged();
            return result;

        }
        void IDisposable.Dispose()
        {
            TablesService.Save -= Save;
           
            TablesService.Delete -= Delete;
        }
    }
}