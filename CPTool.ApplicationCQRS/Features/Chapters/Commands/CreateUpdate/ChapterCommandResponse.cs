using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.Chapters.Commands.CreateUpdate
{
    public class ChapterCommandResponse : BaseResponse
    {
        public ChapterCommandResponse() : base()
        {

        }

        public CommandChapter? ChapterObject { get; set; }
    }
}