using AutoMapper;
using CPTool.ApplicationCQRS.Features.MeasuredVariables.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Contracts.Persistence;


using MediatR;

namespace CPTool.ApplicationCQRSFeatures.MeasuredVariables.Queries.GetDetail
{
    public class GetMeasuredVariableDetailQueryHandler : IRequestHandler<GetMeasuredVariableDetailQuery, CommandMeasuredVariable>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetMeasuredVariableDetailQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<CommandMeasuredVariable> Handle(GetMeasuredVariableDetailQuery request, CancellationToken cancellationToken)
        {
            var table = await _UnitOfWork.RepositoryMeasuredVariable.GetByIdAsync(request.Id);
            var dto = _mapper.Map<CommandMeasuredVariable>(table);
            return dto;
        }
    }
}
