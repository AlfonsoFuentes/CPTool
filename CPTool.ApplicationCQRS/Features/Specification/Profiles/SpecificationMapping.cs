global using CPTool.Domain.Entities;
using AutoMapper;
using CPTool.ApplicationCQRS.Features.Specifications.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.Specifications.Profiles
{
    internal class SpecificationMapping : Profile
    {
        public SpecificationMapping()
        {
            CreateMap<Specification, CommandSpecification>();
            CreateMap<CommandSpecification, Specification>();
            CreateMap<AddSpecification, Specification>();
            CreateMap<CommandSpecification, AddSpecification>();
        }
    }
}
