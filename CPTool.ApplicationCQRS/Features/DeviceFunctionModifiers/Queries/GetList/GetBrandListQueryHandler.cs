using AutoMapper;

using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;

using MediatR;
using CPTool.ApplicationCQRSFeatures.DeviceFunctionModifiers.Queries.GetList;
using CPTool.ApplicationCQRS.Features.DeviceFunctionModifiers.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRSFeatures.DeviceFunctionModifiers.Queries.GetList
{
    public class GetDeviceFunctionModifierListQueryHandler : IRequestHandler<GetDeviceFunctionModifiersListQuery, List<CommandDeviceFunctionModifier>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetDeviceFunctionModifierListQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<List<CommandDeviceFunctionModifier>> Handle(GetDeviceFunctionModifiersListQuery request, CancellationToken cancellationToken)
        {
            var allDeviceFunctionModifier = (await _UnitOfWork.RepositoryDeviceFunctionModifier.GetAllAsync());
            return _mapper.Map<List<CommandDeviceFunctionModifier>>(allDeviceFunctionModifier);
        }
    }
}
