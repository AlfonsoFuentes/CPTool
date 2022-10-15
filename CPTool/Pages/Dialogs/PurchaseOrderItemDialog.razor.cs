using System.Collections.Immutable;
using System.Linq;
using CPTool.Domain.Entities;

namespace CPTool.Pages.Dialogs
{
    //public partial class PurchaseOrderItemDialog
    //{

    //    [Inject]
    //    public IDTOManager<MWODTO, MWO> ManagerMWO { get; set; }


    //    [Parameter]
    //    public PurchaseOrderMWOItemDTO Model { get; set; }

    //    List<MWOItemDTO> MWOItemsDTO = new();
       
    //    async Task ProperInitialize()
    //    {
    //        var mwosearch = Model.PurchaseOrderDTO.PurchaseOrderMWOItemsDTO.FirstOrDefault().MWOItemDTO.MWODTO;
    //        var mwo = await ManagerMWO.GetById(mwosearchId);


    //        MWOItemsDTO = mwo.MWOItemsDTO.Select(x => x).Where(y => !y.PurchaseOrderMWOItemsDTO.Any(z => z.PurchaseOrderDTOId == Model.PurchaseOrderDTOId)).ToList();
    //    }
        

    //}
}
