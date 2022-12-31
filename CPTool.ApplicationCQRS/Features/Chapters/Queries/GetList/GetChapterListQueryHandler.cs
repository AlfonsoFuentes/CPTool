using AutoMapper;

using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;

using MediatR;
using CPTool.ApplicationCQRSFeatures.Chapters.Queries.GetList;
using CPTool.ApplicationCQRS.Features.Chapters.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRSFeatures.Chapters.Queries.GetList
{
    public class GetChapterListQueryHandler : IRequestHandler<GetChaptersListQuery, List<CommandChapter>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetChapterListQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<List<CommandChapter>> Handle(GetChaptersListQuery request, CancellationToken cancellationToken)
        {
            var allChapter = (await _UnitOfWork.RepositoryChapter.GetAllAsync());
            return _mapper.Map<List<CommandChapter>>(allChapter);
        }
    }
}
