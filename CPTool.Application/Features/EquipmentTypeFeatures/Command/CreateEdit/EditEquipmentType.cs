using CPTool.Application.Features.DownPaymentFeatures.Query.GetById;
using CPTool.Application.Features.DownPaymentFeatures.Query.GetList;
using CPTool.Application.Features.EquipmentTypeFeatures.Query.GetById;
using CPTool.Application.Features.EquipmentTypeFeatures.Query.GetList;

namespace CPTool.Application.Features.EquipmentTypeFeatures.CreateEdit
{
    public class EditEquipmentType : EditCommand, IRequest<Result<int>>
    {
       
        public string TagLetter { get; set; } = string.Empty;


        public List<EditEquipmentTypeSub>? EquipmentTypeSubs { get; set; } = new();
        public override T AddDetailtoMaster<T>() 
        {
            T detail = new();
            (detail as EditEquipmentTypeSub)!.EquipmentType = this;
            return detail!;
        }
    }
}
