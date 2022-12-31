namespace CPTool.ApplicationCQRS.Features.EquipmentTypeSubs.Commands.CreateUpdate
{
    public class AddEquipmentTypeSub
    {

       
        public string Name { get; set; } = string.Empty;
        public int? EquipmentTypeId { get; set; }



        public string TagLetter { get; set; } = string.Empty;
    }

}
