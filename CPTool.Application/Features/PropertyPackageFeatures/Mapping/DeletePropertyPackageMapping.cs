



using CPTool.Application.Features.PropertyPackageFeatures.CreateEdit;

namespace CPTool.Application.Features.DeletePropertyPackageFeatures.Mapping
{
    internal class PropertyPackageMapping : Profile
    {
        public PropertyPackageMapping()
        {
            CreateMap<PropertyPackage, EditPropertyPackage>();
            CreateMap<EditPropertyPackage, PropertyPackage>();
            CreateMap<AddPropertyPackage, PropertyPackage>();
            CreateMap<EditPropertyPackage, AddPropertyPackage>();
        }
    }
}
