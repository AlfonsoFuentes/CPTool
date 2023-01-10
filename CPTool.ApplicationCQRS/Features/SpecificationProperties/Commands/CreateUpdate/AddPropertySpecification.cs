using CPTool.ApplicationCQRS.Features.Specifications.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.PropertySpecifications.Commands.CreateUpdate
{
    public class AddPropertySpecification
    {

        public int? SpecificationId { get; set; }

        public string Value { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

    }

}
