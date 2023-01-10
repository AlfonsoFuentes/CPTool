using AutoMapper;

using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;

using MediatR;
using CPTool.ApplicationCQRSFeatures.ControlLoops.Queries.GetList;
using CPTool.ApplicationCQRS.Features.ControlLoops.Commands.CreateUpdate;
using System.Linq.Expressions;

namespace CPTool.ApplicationCQRSFeatures.ControlLoops.Queries.GetList
{
    public class GetControlLoopListQueryHandler : IRequestHandler<GetControlLoopsListQuery, List<CommandControlLoop>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetControlLoopListQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<List<CommandControlLoop>> Handle(GetControlLoopsListQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<ControlLoop, bool>> predicate = request.MWOId == 0 ? x => x.MWOId != 0 : x => x.MWOId == request.MWOId;

            var allControlLoop = (await _UnitOfWork.RepositoryControlLoop.GetAllAsync(predicate));
           
            return _mapper.Map<List<CommandControlLoop>>(allControlLoop);
        }
       
    }
}
