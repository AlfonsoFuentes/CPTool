namespace CPTool.ApplicationCQRS.Features.ProcessFluids.Commands.CreateUpdate
{
    public class AddProcessFluid
    {

       
        public string Name { get; set; } = string.Empty;
        public int? PropertyPackageId { get; set; }
        public string TagLetter { get; set; } = "";
    }

}
