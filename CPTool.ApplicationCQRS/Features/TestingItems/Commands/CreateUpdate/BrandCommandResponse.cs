using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.TestingItems.Commands.CreateUpdate
{
    public class TestingItemCommandResponse : BaseResponse
    {
        public TestingItemCommandResponse() : base()
        {

        }

        public CommandTestingItem? TestingItemObject { get; set; }
    }
}