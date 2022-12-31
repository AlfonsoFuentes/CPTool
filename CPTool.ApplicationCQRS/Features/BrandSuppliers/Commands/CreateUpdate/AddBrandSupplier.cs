namespace CPTool.ApplicationCQRS.Features.BrandSuppliers.Commands.CreateUpdate
{
    public class AddBrandSupplier
    {

     
        public string Name { get; set; } = string.Empty;
      
        public int BrandId { get; set; }
        public int SupplierId { get; set; }
    }

}
