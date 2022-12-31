using CPTool.ApplicationCQRS.Features.Chapters.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.Chapters.Queries.GetDetail
{
    public class GetChapterDetailQuery : IRequest<CommandChapter>
    {
        public int Id { get; set; }
    }
}
