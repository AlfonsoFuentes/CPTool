global using CPTool.Domain.Entities;
using AutoMapper;
using CPTool.ApplicationCQRS.Features.PropertySpecifications.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.PropertySpecifications.Profiles
{
    internal class PropertySpecificationMapping : Profile
    {
        public PropertySpecificationMapping()
        {
            CreateMap<PropertySpecification, CommandPropertySpecification>();
            CreateMap<CommandPropertySpecification, PropertySpecification>();
            CreateMap<AddPropertySpecification, PropertySpecification>();
            CreateMap<CommandPropertySpecification, AddPropertySpecification>();
        }
    }
}
