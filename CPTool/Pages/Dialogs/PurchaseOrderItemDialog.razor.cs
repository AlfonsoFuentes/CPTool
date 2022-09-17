using System.Collections.Immutable;
using System.Linq;

namespace CPTool.Pages.Dialogs
{
    public partial class PurchaseOrderItemDialog
    {
       



        [Parameter]
        public PurchaseOrderMWOItemDTO Model { get; set; }

        List<MWOItemDTO> MWOItemDTOs = new();
       
        async Task ProperInitialize()
        {
            var mwosearch = Model.PurchaseOrderDTO.PurchaseOrderMWOItemDTOs.FirstOrDefault().MWOItemDTO.MWODTO;
            var mwo = (await TablesService.ManMWO.GetById(mwosearch.Id)).Data;


            MWOItemDTOs = mwo.MWOItemDTOs.Select(x => x).Where(y => !y.PurchaseOrderMWOItemDTOs.Any(z => z.PurchaseOrderId == Model.PurchaseOrderId)).ToList();
        }
        

    }
}
