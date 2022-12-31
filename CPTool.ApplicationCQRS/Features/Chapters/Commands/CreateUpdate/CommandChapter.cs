using CPTool.ApplicationCQRS.Responses;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.Chapters.Commands.CreateUpdate
{
    public class CommandChapter : CommandBase, IRequest<ChapterCommandResponse>
    {


        public string LetterName => $"{Letter}-{Name}";

        public string? Letter { get; set; }

    }

}
