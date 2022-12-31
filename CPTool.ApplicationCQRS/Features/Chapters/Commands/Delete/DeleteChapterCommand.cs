using MediatR;

namespace CPTool.ApplicationCQRSFeatures.Chapters.Commands.Delete
{
    public class DeleteChapterCommand : IRequest<DeleteChapterCommandResponse>
    {
        public int Id { get; set; }
    }
}
