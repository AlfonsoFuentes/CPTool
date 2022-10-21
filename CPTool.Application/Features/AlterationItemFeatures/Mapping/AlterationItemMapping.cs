

using CPTool.Application.Features.AlterationItemFeatures.CreateEdit;
using System.ComponentModel.Design;

namespace CPTool.Application.Features.AlterationItemFeatures.Mapping
{
    internal class AlterationItemMapping : Profile
    {
        public AlterationItemMapping()
        {
            CreateMap<AlterationItem, EditAlterationItem>();

            CreateMap<AddAlterationItem, AlterationItem>();
            CreateMap<EditAlterationItem, AlterationItem>();
            CreateMap<EditAlterationItem, AddAlterationItem>();
        }
    }
}
