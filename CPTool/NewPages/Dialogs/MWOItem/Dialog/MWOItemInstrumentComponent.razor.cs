using CPTool.Application.Features.BrandFeatures.CreateEdit;
using CPTool.Application.Features.ChapterFeatures.CreateEdit;
using CPTool.Application.Features.EquipmentItemFeatures.CreateEdit;
using CPTool.Application.Features.EquipmentTypeSubFeatures.Query.GetList;
using CPTool.Application.Features.GasketsFeatures.CreateEdit;
using CPTool.Application.Features.InstrumentItemFeatures.CreateEdit;
using CPTool.Application.Features.MaterialFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.SupplierFeatures.CreateEdit;
using CPTool.Domain.Entities;

namespace CPTool.NewPages.Dialogs.MWOItem.Dialog
{
    public partial class MWOItemInstrumentComponent
    {
        [CascadingParameter]
        protected MWOItemDialog DialogParent { get; set; }
        protected EditInstrumentItem Model => DialogParent.Model.InstrumentItem;

       
        void BrandChanged(EditBrand brand)
        {

            Model.iSupplier = new();
            StateHasChanged();
        }
        
       
        
       
    }
}
