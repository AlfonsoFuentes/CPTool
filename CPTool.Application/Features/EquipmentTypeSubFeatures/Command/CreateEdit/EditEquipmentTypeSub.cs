namespace CPTool.Application.Features.EquipmentTypeSubFeatures.CreateEdit
{
    public class EditEquipmentTypeSub : EditCommand, IRequest<Result<int>>
    {
       
        public string TagLetter { get; set; } = string.Empty;


    }

}
