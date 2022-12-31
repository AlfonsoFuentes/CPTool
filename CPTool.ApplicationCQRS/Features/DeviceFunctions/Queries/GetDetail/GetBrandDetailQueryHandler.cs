using AutoMapper;
using CPTool.ApplicationCQRS.Features.DeviceFunctions.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Contracts.Persistence;


using MediatR;

namespace CPTool.ApplicationCQRSFeatures.DeviceFunctions.Queries.GetDetail
{
    public class GetDeviceFunctionDetailQueryHandler : IRequestHandler<GetDeviceFunctionDetailQuery, CommandDeviceFunction>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetDeviceFunctionDetailQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<CommandDeviceFunction> Handle(GetDeviceFunctionDetailQuery request, CancellationToken cancellationToken)
        {
            var table = await _UnitOfWork.RepositoryDeviceFunction.GetByIdAsync(request.Id);
            var dto = _mapper.Map<CommandDeviceFunction>(table);
            return dto;
        }
    }
}
