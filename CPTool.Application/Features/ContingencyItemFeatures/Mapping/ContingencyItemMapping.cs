



using CPTool.Application.Features.ContingencyItemFeatures.CreateEdit;

namespace CPTool.Application.Features.ContingencyItemFeatures.Mapping
{
    internal class ContingencyItemMapping : Profile
    {
        public ContingencyItemMapping()
        {
            CreateMap<ContingencyItem, EditContingencyItem>();
           

            CreateMap<EditContingencyItem, ContingencyItem>();
            CreateMap<AddContingencyItem, ContingencyItem>();
            CreateMap<EditContingencyItem, AddContingencyItem>();
        }
    }
}
