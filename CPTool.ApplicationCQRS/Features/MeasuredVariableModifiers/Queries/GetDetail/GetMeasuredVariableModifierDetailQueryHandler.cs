using AutoMapper;
using CPTool.ApplicationCQRS.Features.MeasuredVariableModifiers.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Contracts.Persistence;


using MediatR;

namespace CPTool.ApplicationCQRSFeatures.MeasuredVariableModifiers.Queries.GetDetail
{
    public class GetMeasuredVariableModifierDetailQueryHandler : IRequestHandler<GetMeasuredVariableModifierDetailQuery, CommandMeasuredVariableModifier>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetMeasuredVariableModifierDetailQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<CommandMeasuredVariableModifier> Handle(GetMeasuredVariableModifierDetailQuery request, CancellationToken cancellationToken)
        {
            var table = await _UnitOfWork.RepositoryMeasuredVariableModifier.GetByIdAsync(request.Id);
            var dto = _mapper.Map<CommandMeasuredVariableModifier>(table);
            return dto;
        }
    }
}
