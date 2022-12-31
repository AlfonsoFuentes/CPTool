using AutoMapper;

using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;

using MediatR;
using CPTool.ApplicationCQRSFeatures.MeasuredVariables.Queries.GetList;
using CPTool.ApplicationCQRS.Features.MeasuredVariables.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRSFeatures.MeasuredVariables.Queries.GetList
{
    public class GetMeasuredVariableListQueryHandler : IRequestHandler<GetMeasuredVariablesListQuery, List<CommandMeasuredVariable>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetMeasuredVariableListQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<List<CommandMeasuredVariable>> Handle(GetMeasuredVariablesListQuery request, CancellationToken cancellationToken)
        {
            var allMeasuredVariable = (await _UnitOfWork.RepositoryMeasuredVariable.GetAllAsync());
            return _mapper.Map<List<CommandMeasuredVariable>>(allMeasuredVariable);
        }
    }
}
