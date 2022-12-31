using CPTool.ApplicationCQRS.Responses;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.Materials.Commands.CreateUpdate
{
    public class CommandMaterial : CommandBase, IRequest<MaterialCommandResponse>
    {



        public string? Abbreviation { get; set; } = string.Empty;

    }

}
