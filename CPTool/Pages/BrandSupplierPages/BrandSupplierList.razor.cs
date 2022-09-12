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

            TablesService.Delete += Delete;
        }
        void RowMasterClicked(BrandDTO dto)
        {
            SelectedMaster = dto;
            //SelectedDetail = new();

        }

        void RowDetailClicked(SupplierDTO dto)
        {
            //SelectedMaster = new();
            SelectedDetail = dto;

        }

        async Task<DialogResult> ShowDialogMaster(BrandDTO dto)
        {
            SelectedMaster = dto;
            BrandSupplierDTO bs = new();
            bs.BrandDTO = SelectedMaster;
            bs.SupplierDTO = SelectedDetail;
            TablesService.Save += SaveBrand;
            return OnShowDialogMaster == null ? await ToolDialogService.ShowDialogName<BrandDTO>(dto) : await OnShowDialogMaster.Invoke(bs);


        }

        async Task<DialogResult> ShowDialogDetail(SupplierDTO dto)
        {

            SelectedDetail = dto;
            BrandSupplierDTO bs = new();
            bs.BrandDTO = SelectedMaster;
            bs.SupplierDTO = SelectedDetail;
            TablesService.Save += SaveSupplier;

            return OnShowDialogDetail == null ? await ToolDialogService.ShowDialogName<SupplierDTO>(dto) : await OnShowDialogDetail.Invoke(bs);


        }


        async Task<IResult<IAuditableEntityDTO>> SaveBrand(IAuditableEntityDTO dto)
        {
            var BrandSupplier = dto as BrandSupplierDTO;

            var result = await TablesService.ManBrand.AddUpdate(BrandSupplier.BrandDTO, _cts.Token);
            if (result.Succeeded)
            {
               
                if (BrandSupplier.BrandId != 0 && BrandSupplier.SupplierId != 0)
                {
                    var result2 = await TablesService.ManBrandSupplier.AddUpdate(BrandSupplier, _cts.Token);
                    if(result2.Succeeded)
                    {
                        await TablesService.ManBrand.UpdateList();
                        await TablesService.ManSupplier.UpdateList();
                    }

                }
               
                SelectedMaster = (await TablesService.ManBrand.GetById(result.Data.Id)).Data;
            }

            StateHasChanged();
            TablesService.Save -= SaveBrand;
            return await Result<AuditableEntityDTO>.SuccessAsync(new(), "Updated");
        }
        async Task<IResult<IAuditableEntityDTO>> SaveSupplier(IAuditableEntityDTO dto)
        {
            var BrandSupplier = dto as BrandSupplierDTO;
            var result = await TablesService.ManSupplier.AddUpdate(BrandSupplier.SupplierDTO, _cts.Token);
            if (result.Succeeded)
            {
             
                if (BrandSupplier.BrandId != 0 && BrandSupplier.SupplierId != 0)
                {
                    var result2 = await TablesService.ManBrandSupplier.AddUpdate(BrandSupplier, _cts.Token);
                    if (result2.Succeeded)
                    {
                        await TablesService.ManBrand.UpdateList();
                        await TablesService.ManSupplier.UpdateList();
                    }
                }

               
                SelectedDetail =(await TablesService.ManSupplier.GetById(result.Data.Id)).Data; 
            }
            StateHasChanged();

            TablesService.Save -= SaveSupplier;

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
                    StateHasChanged();
                }
                return result;
            }
            else if (dto is SupplierDTO)
            {
                result = await TablesService.ManSupplier.Delete(dto.Id, _cts.Token);
                if (result.Succeeded)
                {
                    StateHasChanged();
                }
                return result;
            }

            return result;

        }
        void IDisposable.Dispose()
        {

            TablesService.ManSupplier.PostEvent -= TablesService.ManBrand.UpdateList;
            TablesService.ManBrand.PostEvent -= TablesService.ManSupplier.UpdateList;
            TablesService.Delete -= Delete;
        }
    }
}