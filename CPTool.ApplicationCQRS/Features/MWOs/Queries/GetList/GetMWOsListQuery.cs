using CPTool.ApplicationCQRS.Features.MWOs.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.MWOs.Queries.GetList
{
    public class GetMWOsListQuery : IRequest<List<CommandMWO>>
    {
        public bool IsMainScreenList { get; set; } = false;

    }
}
