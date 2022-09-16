using CPTool.DTOS;
using CPTool.Entities;
using CPTool.Implementations;
using CPTool.Interfaces;
using System.Threading;

namespace CPTool.Shared
{
    public class TablesService : IDisposable
    {
        public IDTOManager<PurchaseOrderDTO, PurchaseOrder> ManPurchaseOrder { get; set; }
        public IDTOManager<PurchaseOrderMWOItemDTO, PurchaseOrderMWOItem> ManPurchaseOrderMWOItem { get; set; }
        public IDTOManager<VendorCodeDTO, VendorCode> ManVendorCode { get; set; }
        public IDTOManager<TaxCodeLDDTO, TaxCodeLD> ManTaxCodeLD { get; set; }
        public IDTOManager<TaxCodeLPDTO, TaxCodeLP> ManTaxCodeLP { get; set; }

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
            IDTOManager<EquipmentItemDTO, EquipmentItem> manItemEquipment ,
            IDTOManager<VendorCodeDTO, VendorCode> manVendorCode,
            IDTOManager<TaxCodeLDDTO, TaxCodeLD> manTaxCodeLD,
            IDTOManager<TaxCodeLPDTO, TaxCodeLP> manTaxCodeLP,
            IDTOManager<PurchaseOrderDTO, PurchaseOrder> manPurchaseOrder,
            IDTOManager<PurchaseOrderMWOItemDTO, PurchaseOrderMWOItem> manPurchaseOrderMWOItem
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
            ManVendorCode = manVendorCode;
            ManTaxCodeLD = manTaxCodeLD;
            ManTaxCodeLP = manTaxCodeLP;
            ManPurchaseOrder = manPurchaseOrder;
             ManPurchaseOrderMWOItem=manPurchaseOrderMWOItem;


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
            await ManBrandSupplier.UpdateList();
            await ManBrand.UpdateList();
            await ManSupplier.UpdateList();
          

            await ManItemEquipment.UpdateList();
            await ManMWO.UpdateList();
            await ManMWOItem.UpdateList();

            await ManVendorCode.UpdateList();
            await ManTaxCodeLD.UpdateList();
            await ManTaxCodeLP.UpdateList();
            await ManPurchaseOrder.UpdateList();
            await ManPurchaseOrderMWOItem.UpdateList();
        }
       
        public Func<IAuditableEntityDTO, Task<IResult<IAuditableEntityDTO>>> Save { get; set; }
        public Func<IAuditableEntityDTO, Task<IResult<int>>> Delete { get; set; }
        //public Action UpdateForm { get; set; }
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
       

        public void Dispose()
        {
           
        }
    }
}