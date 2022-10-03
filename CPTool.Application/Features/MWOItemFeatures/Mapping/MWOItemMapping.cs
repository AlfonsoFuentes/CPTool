



using CPTool.Application.Features.MWOItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.MWOItemFeatures.Mapping
{
    internal class MWOItemMapping : Profile
    {
        public MWOItemMapping()
        {
            CreateMap<MWOItem, AddEditMWOItemCommand>();
            ;

            CreateMap<AddEditMWOItemCommand, MWOItem>();
        }
    }
}
