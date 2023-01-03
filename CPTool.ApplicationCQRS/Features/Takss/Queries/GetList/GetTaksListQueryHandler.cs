using AutoMapper;

using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;

using MediatR;
using CPTool.ApplicationCQRSFeatures.Takss.Queries.GetList;
using CPTool.ApplicationCQRS.Features.Takss.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRSFeatures.Takss.Queries.GetList
{
    public class GetTaksListQueryHandler : IRequestHandler<GetTakssListQuery, List<CommandTaks>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetTaksListQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<List<CommandTaks>> Handle(GetTakssListQuery request, CancellationToken cancellationToken)
        {
            Func<IQueryable<Taks>, IOrderedQueryable<Taks>> orderBy = y => y.OrderBy(z => z.TaksStatus);
            var allTaks = await _UnitOfWork.RepositoryTaks.GetAllAsync(orderBy);
            return _mapper.Map<List<CommandTaks>>(allTaks);
        }
    }
}
