using CPTool.ApplicationCQRS.Features.Chapters.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.Chapters.Queries.GetList
{
    public class GetChaptersListQuery : IRequest<List<CommandChapter>>
    {

    }
}
