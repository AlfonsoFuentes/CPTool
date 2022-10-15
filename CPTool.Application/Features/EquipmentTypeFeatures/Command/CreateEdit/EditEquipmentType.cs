namespace CPTool.Application.Features.EquipmentTypeFeatures.CreateEdit
{
    public class EditEquipmentType : EditCommand, IRequest<Result<int>>
    {

        public string TagLetter { get; set; } = string.Empty;


        public List<EditEquipmentTypeSub>? EquipmentTypeSubs { get; set; }
        public override T AddDetailtoMaster<T>() 
        {
            T detail = new();
            (detail as AddEquipmentTypeSub)!.EquipmentTypeId = Id;
            return detail!;
        }
    }
}
