using AutoMapper;

using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;

using MediatR;
using CPTool.ApplicationCQRSFeatures.DeviceFunctions.Queries.GetList;
using CPTool.ApplicationCQRS.Features.DeviceFunctions.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRSFeatures.DeviceFunctions.Queries.GetList
{
    public class GetDeviceFunctionListQueryHandler : IRequestHandler<GetDeviceFunctionsListQuery, List<CommandDeviceFunction>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetDeviceFunctionListQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<List<CommandDeviceFunction>> Handle(GetDeviceFunctionsListQuery request, CancellationToken cancellationToken)
        {
            var allDeviceFunction = (await _UnitOfWork.RepositoryDeviceFunction.GetAllAsync());
            return _mapper.Map<List<CommandDeviceFunction>>(allDeviceFunction);
        }
    }
}
