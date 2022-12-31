using CPTool.Domain.Enums;

namespace CPTool.ApplicationCQRS.Features.Brands.Commands.CreateUpdate
{
    public class AddBrand
    {

       
        public string Name { get; set; } = string.Empty;
        public BrandType BrandType { get; set; }
    }

}
