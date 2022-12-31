using AutoMapper;
using CPTool.ApplicationCQRS.Features.Chapters.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Contracts.Persistence;


using MediatR;

namespace CPTool.ApplicationCQRSFeatures.Chapters.Queries.GetDetail
{
    public class GetChapterDetailQueryHandler : IRequestHandler<GetChapterDetailQuery, CommandChapter>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetChapterDetailQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<CommandChapter> Handle(GetChapterDetailQuery request, CancellationToken cancellationToken)
        {
            var table = await _UnitOfWork.RepositoryChapter.FindAsync(request.Id);
            var dto = _mapper.Map<CommandChapter>(table);
            return dto;
        }
    }
}
