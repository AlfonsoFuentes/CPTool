using AutoMapper;
using CPTool.ApplicationCQRS.Features.EquipmentItems.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Contracts.Persistence;


using MediatR;

namespace CPTool.ApplicationCQRSFeatures.EquipmentItems.Queries.GetDetail
{
    public class GetEquipmentItemDetailQueryHandler : IRequestHandler<GetEquipmentItemDetailQuery, CommandEquipmentItem>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetEquipmentItemDetailQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<CommandEquipmentItem> Handle(GetEquipmentItemDetailQuery request, CancellationToken cancellationToken)
        {
            var table = await _UnitOfWork.RepositoryEquipmentItem.GetByIdAsync(request.Id);
            var dto = _mapper.Map<CommandEquipmentItem>(table);
            return dto;
        }
    }
}
