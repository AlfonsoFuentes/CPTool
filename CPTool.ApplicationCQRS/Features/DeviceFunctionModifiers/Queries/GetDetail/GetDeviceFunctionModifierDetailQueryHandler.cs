using AutoMapper;
using CPTool.ApplicationCQRS.Features.DeviceFunctionModifiers.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Contracts.Persistence;


using MediatR;

namespace CPTool.ApplicationCQRSFeatures.DeviceFunctionModifiers.Queries.GetDetail
{
    public class GetDeviceFunctionModifierDetailQueryHandler : IRequestHandler<GetDeviceFunctionModifierDetailQuery, CommandDeviceFunctionModifier>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetDeviceFunctionModifierDetailQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<CommandDeviceFunctionModifier> Handle(GetDeviceFunctionModifierDetailQuery request, CancellationToken cancellationToken)
        {
            var table = await _UnitOfWork.RepositoryDeviceFunctionModifier.GetByIdAsync(request.Id);
            var dto = _mapper.Map<CommandDeviceFunctionModifier>(table);
            return dto;
        }
    }
}
