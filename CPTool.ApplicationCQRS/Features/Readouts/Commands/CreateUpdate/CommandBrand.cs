using CPTool.ApplicationCQRS.Responses;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.Readouts.Commands.CreateUpdate
{
    public class CommandReadout : CommandBase, IRequest<ReadoutCommandResponse>
    {


        public string? TagLetter { get; set; }=string.Empty;

    }

}
