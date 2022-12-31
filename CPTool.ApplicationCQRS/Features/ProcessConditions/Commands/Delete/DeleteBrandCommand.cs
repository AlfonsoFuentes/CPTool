using MediatR;

namespace CPTool.ApplicationCQRSFeatures.ProcessConditions.Commands.Delete
{
    public class DeleteProcessConditionCommand : IRequest<DeleteProcessConditionCommandResponse>
    {
        public int Id { get; set; }
    }
}
