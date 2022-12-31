using AutoMapper;

using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;

using MediatR;
using CPTool.ApplicationCQRSFeatures.MeasuredVariableModifiers.Queries.GetList;
using CPTool.ApplicationCQRS.Features.MeasuredVariableModifiers.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRSFeatures.MeasuredVariableModifiers.Queries.GetList
{
    public class GetMeasuredVariableModifierListQueryHandler : IRequestHandler<GetMeasuredVariableModifiersListQuery, List<CommandMeasuredVariableModifier>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetMeasuredVariableModifierListQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<List<CommandMeasuredVariableModifier>> Handle(GetMeasuredVariableModifiersListQuery request, CancellationToken cancellationToken)
        {
            var allMeasuredVariableModifier = (await _UnitOfWork.RepositoryMeasuredVariableModifier.GetAllAsync());
            return _mapper.Map<List<CommandMeasuredVariableModifier>>(allMeasuredVariableModifier);
        }
    }
}
