global using CPTool.Domain.Entities;
using AutoMapper;
using CPTool.ApplicationCQRS.Features.TestingItems.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.TestingItems.Profiles
{
    internal class TestingItemMapping : Profile
    {
        public TestingItemMapping()
        {
            CreateMap<TestingItem, CommandTestingItem>();
            CreateMap<CommandTestingItem, TestingItem>();
            CreateMap<AddTestingItem, TestingItem>();
            CreateMap<CommandTestingItem, AddTestingItem>();
        }
    }
}
