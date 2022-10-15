namespace CPTool.Application.Features.Base
{
    internal class AddEditMapping : Profile
    {
        public AddEditMapping()
        {
            CreateMap<BaseDomainModel, EditCommand>();
            CreateMap<AddCommand, BaseDomainModel>();
            CreateMap<EditCommand, BaseDomainModel>();
        }
    }
}
