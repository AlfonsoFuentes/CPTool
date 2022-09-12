using CPTool.DTOS;
using CPTool.Entities;
using CPTool.Implementations;
using CPTool.Interfaces;
using System.Threading;

namespace CPTool.Shared
{
    public class TablesService : IDisposable
    {

        public IDTOManager<BrandDTO, Brand> ManBrand { get; set; }
        public IDTOManager<SupplierDTO, Supplier> ManSupplier { get; set; }
        public IDTOManager<BrandSupplierDTO, BrandSupplier> ManBrandSupplier { get; set; }


        public IDTOManager<MaterialDTO, Material> ManMaterial { get; set; }
        public IDTOManager<GasketDTO, Gasket> ManGasket { get; set; }
        public IDTOManager<UnitaryBasePrizeDTO, UnitaryBasePrize> ManUnitaryPrize { get; set; }
        public IDTOManager<ChapterDTO, Chapter> ManChapter { get; set; }
        public IDTOManager<MWOTypeDTO, MWOType> ManMWOType { get; set; }
        public IDTOManager<MWODTO, MWO> ManMWO { get; set; }
        public IDTOManager<MWOItemDTO, MWOItem> ManMWOItem { get; set; }
        public IDTOManager<EquipmentTypeDTO, EquipmentType> ManEquipmentType { get; set; }
        public IDTOManager<EquipmentTypeSubDTO, EquipmentTypeSub> ManEquipmentTypeSub { get; set; }
        public IDTOManager<EquipmentItemDTO, EquipmentItem> ManItemEquipment { get; set; }

        public TablesService(
            IDTOManager<BrandSupplierDTO, BrandSupplier> manBrandSupplier,
            IDTOManager<MWOTypeDTO, MWOType> manMWOType,
            IDTOManager<MWODTO, MWO> manMWO,
            IDTOManager<MWOItemDTO, MWOItem> manMWOItem,
            IDTOManager<EquipmentTypeDTO, EquipmentType> manEquipmentType,
            IDTOManager<EquipmentTypeSubDTO, EquipmentTypeSub> manEquipmentTypeSub,
            IDTOManager<ChapterDTO, Chapter> manChapter,
            IDTOManager<UnitaryBasePrizeDTO, UnitaryBasePrize> manUnitaryPrize,
            IDTOManager<GasketDTO, Gasket> manGasket,
            IDTOManager<MaterialDTO, Material> manMaterial,
            IDTOManager<BrandDTO, Brand> manBrand,
            IDTOManager<SupplierDTO, Supplier> manSupplier,
            IDTOManager<EquipmentItemDTO, EquipmentItem> manItemEquipment
            )

        {

            ManEquipmentType = manEquipmentType;
            ManEquipmentTypeSub = manEquipmentTypeSub;

            ManMWOType = manMWOType;
            ManMWO = manMWO;
            ManMWOItem = manMWOItem;
            ManChapter = manChapter;
            ManUnitaryPrize = manUnitaryPrize;
            ManGasket = manGasket;
            ManMaterial = manMaterial;
            ManBrand = manBrand;
            ManSupplier = manSupplier;
            ManItemEquipment = manItemEquipment;
            ManBrandSupplier = manBrandSupplier;
            ManBrand.PostEvent += UpdateBrandSupplierDTO;
            ManSupplier.PostEvent += UpdateBrandSupplierDTO;
            ManBrandSupplier.PostEvent += UpdateBrandSupplierDTO;
            ManMWO.PostEvent += UpdateMWO;
            ManMWOItem.PostEvent += UpdateMWO;
        }

        public async Task Initialize()
        {
            await ManChapter.UpdateList();
            await ManUnitaryPrize.UpdateList();
            await ManGasket.UpdateList();
            await ManMaterial.UpdateList();
            await ManEquipmentType.UpdateList();
            await ManEquipmentTypeSub.UpdateList();
            await ManMWOType.UpdateList();

            await ManBrand.UpdateList();
            await ManSupplier.UpdateList();
            await ManBrandSupplier.UpdateList();

            await ManItemEquipment.UpdateList();
            await ManMWO.UpdateList();
            await ManMWOItem.UpdateList();

            //await ManMWOType.Test1(new CancellationToken());
            //await ManMWOType.Test2(new CancellationToken());
        }
        void UpdateBrandSupplierDTO()
        {
            //foreach (var row in ManBrandSupplier.List)
            //{
            //    row.BrandDTO = ManBrand.List.FirstOrDefault(x => x.Id == row.BrandId);
            //    row.SupplierDTO = ManSupplier.List.FirstOrDefault(x => x.Id == row.SupplierId);
            //}
            //foreach (var item in ManBrand.List)
            //{
            //    foreach(var row in item.BrandSupplierDTOs)
            //    {
            //        row.BrandDTO = ManBrand.List.FirstOrDefault(x => x.Id == row.BrandId);
            //        row.SupplierDTO = ManSupplier.List.FirstOrDefault(x => x.Id == row.SupplierId);
            //    }

            //}
            //foreach (var item in ManSupplier.List)
            //{
            //    foreach (var row in item.BrandSupplierDTOs)
            //    {
            //        row.BrandDTO = ManBrand.List.FirstOrDefault(x => x.Id == row.BrandId);
            //        row.SupplierDTO = ManSupplier.List.FirstOrDefault(x => x.Id == row.SupplierId);
            //    }

            //}
        }
        void UpdateMWO()
        {
            foreach (var mwo in ManMWO.List)
            {
                foreach (var item in mwo.MWOItemDTOs)
                {
                    if (item.EquipmentItemDTO != null && item.EquipmentItemDTO.Id != 0)
                    {
                        var row = item.EquipmentItemDTO;

                        //row.BrandDTO = ManBrand.List.Any(x => x.Id == row.BrandId) ? ManBrand.List.FirstOrDefault(x => x.Id == row.BrandId) : new();
                        //row.SupplierDTO = ManSupplier.List.Any(x => x.Id == row.SupplierId) ? ManSupplier.List.FirstOrDefault(x => x.Id == row.SupplierId) : new();
                        //row.GasketDTO = ManGasket.List.Any(x => x.Id == row.GasketId) ? ManGasket.List.FirstOrDefault(x => x.Id == row.GasketId) : new();
                        //row.EquipmentTypeDTO = ManEquipmentType.List.Any(x => x.Id == row.EquipmentTypeId) ? ManEquipmentType.List.FirstOrDefault(x => x.Id == row.EquipmentTypeId) : new();
                        //row.EquipmentTypeSubDTO = ManEquipmentTypeSub.List.Any(x => x.Id == row.EquipmentTypeSubId) ? ManEquipmentTypeSub.List.FirstOrDefault(x => x.Id == row.EquipmentTypeSubId) : new();
                        //row.InnerMaterialDTO = ManMaterial.List.Any(x => x.Id == row.InnerMaterialId) ? ManMaterial.List.FirstOrDefault(x => x.Id == row.InnerMaterialId) : new();
                        //row.OuterMaterialDTO = ManMaterial.List.Any(x => x.Id == row.OuterMaterialId) ? ManMaterial.List.FirstOrDefault(x => x.Id == row.OuterMaterialId) : new();

                    }
                }
            }

        }
        public Func<IAuditableEntityDTO, Task<IResult<IAuditableEntityDTO>>> Save { get; set; }
        public Func<IAuditableEntityDTO, Task<IResult<int>>> Delete { get; set; }
        public Action UpdateForm { get; set; }
        public async Task<IResult<IAuditableEntityDTO>> OnSave(IAuditableEntityDTO result)
        {
            if (Save != null)
            {
                return await Save!.Invoke(result);

            }

            return await Result<IAuditableEntityDTO>.FailAsync("Not Event");
        }
        public async Task<IResult<int>> OnDelete(IAuditableEntityDTO result)
        {
            if (Delete != null)
            {
                return await Delete!.Invoke(result);

            }


            return await Result<int>.FailAsync("Not Event");
        }
        public void OnUpdateForm()
        {
            if (UpdateForm != null) UpdateForm.Invoke();
        }


        public void Dispose()
        {
            ManBrand.PostEvent -= UpdateBrandSupplierDTO;
            ManSupplier.PostEvent -= UpdateBrandSupplierDTO;
            ManBrandSupplier.PostEvent -= UpdateBrandSupplierDTO;
            ManMWO.PostEvent -= UpdateMWO;
            ManMWOItem.PostEvent -= UpdateMWO;
        }
    }
}