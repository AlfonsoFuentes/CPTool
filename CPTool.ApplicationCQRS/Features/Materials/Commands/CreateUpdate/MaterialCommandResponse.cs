using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.Materials.Commands.CreateUpdate
{
    public class MaterialCommandResponse : BaseResponse
    {
        public MaterialCommandResponse() : base()
        {

        }

        public CommandMaterial? MaterialObject { get; set; }
    }
}