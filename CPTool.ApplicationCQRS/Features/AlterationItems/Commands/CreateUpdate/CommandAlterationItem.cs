using CPTool.ApplicationCQRS.Responses;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.AlterationItems.Commands.CreateUpdate
{
    public class CommandAlterationItem : CommandBase, IRequest<AlterationItemCommandResponse>
    {


        public string? CostCenter { get; set; } = string.Empty;

    }

}
