using CPTool.ApplicationCQRS.Features.PipeAccesorys.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PipeDiameters.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Responses;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.PipeClasss.Commands.CreateUpdate
{
    public class CommandPipeClass : CommandBase, IRequest<PipeClassCommandResponse>
    {


        public List<CommandPipeDiameter>? PipeDiameters { get; set; } = new();

        public List<CommandPipeAccesory>? PipeAccesorys { get; set; } = new();

    }

}
