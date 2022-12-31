using CPTool.ApplicationCQRS.Features.SignalTypes.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.SignalTypes.Queries.GetDetail
{
    public class GetSignalTypeDetailQuery : IRequest<CommandSignalType>
    {
        public int Id { get; set; }
    }
}
