namespace CPTool.ApplicationCQRS.Features.Suppliers.Commands.CreateUpdate
{
    public class AddSupplier
    {

       
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = "";
        public string Phone { get; set; } = "";


        public string Email { get; set; } = "";
        public string ContactPerson { get; set; } = "";


        public int? TaxCodeLPId { get; set; }
        public string? VendorCode { get; set; } = "";
        public int? TaxCodeLDId { get; set; }
    }

}
