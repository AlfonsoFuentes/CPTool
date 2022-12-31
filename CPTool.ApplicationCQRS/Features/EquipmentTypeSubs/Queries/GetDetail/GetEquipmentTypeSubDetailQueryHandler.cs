using AutoMapper;
using CPTool.ApplicationCQRS.Features.EquipmentTypeSubs.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Contracts.Persistence;


using MediatR;

namespace CPTool.ApplicationCQRSFeatures.EquipmentTypeSubs.Queries.GetDetail
{
    public class GetEquipmentTypeSubDetailQueryHandler : IRequestHandler<GetEquipmentTypeSubDetailQuery, CommandEquipmentTypeSub>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetEquipmentTypeSubDetailQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<CommandEquipmentTypeSub> Handle(GetEquipmentTypeSubDetailQuery request, CancellationToken cancellationToken)
        {
            var table = await _UnitOfWork.RepositoryEquipmentTypeSub.GetByIdAsync(request.Id);
            var dto = _mapper.Map<CommandEquipmentTypeSub>(table);
            return dto;
        }
    }
}
