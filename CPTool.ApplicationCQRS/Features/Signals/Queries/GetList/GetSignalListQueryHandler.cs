using AutoMapper;

using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;

using MediatR;
using CPTool.ApplicationCQRSFeatures.Signals.Queries.GetList;
using CPTool.ApplicationCQRS.Features.Signals.Commands.CreateUpdate;
using System.Linq.Expressions;

namespace CPTool.ApplicationCQRSFeatures.Signals.Queries.GetList
{
    public class GetSignalListQueryHandler : IRequestHandler<GetSignalsListQuery, List<CommandSignal>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetSignalListQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<List<CommandSignal>> Handle(GetSignalsListQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Signal, bool>> predicate = request.MWOId == 0 ? x => x.MWOId != 0 : x => x.MWOId == request.MWOId;
            Func<IQueryable<Signal>, IOrderedQueryable<Signal>> orderBy = y => y.OrderBy(z => z.Name);
            var allSignal = (await _UnitOfWork.RepositorySignal.GetAllAsync(predicate));
           
            return _mapper.Map<List<CommandSignal>>(allSignal);
        }

       
    }
}
