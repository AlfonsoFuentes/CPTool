global using CPTool.Domain.Entities;
using AutoMapper;
using CPTool.ApplicationCQRS.Features.PropertyPackages.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.PropertyPackages.Profiles
{
    internal class PropertyPackageMapping : Profile
    {
        public PropertyPackageMapping()
        {
            CreateMap<PropertyPackage, CommandPropertyPackage>();
            CreateMap<CommandPropertyPackage, PropertyPackage>();
            CreateMap<AddPropertyPackage, PropertyPackage>();
            CreateMap<CommandPropertyPackage, AddPropertyPackage>();
        }
    }
}
