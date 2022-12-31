using AutoMapper;
using CPTool.ApplicationCQRS.Features.EquipmentTypes.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Contracts.Persistence;


using MediatR;

namespace CPTool.ApplicationCQRSFeatures.EquipmentTypes.Queries.GetDetail
{
    public class GetEquipmentTypeDetailQueryHandler : IRequestHandler<GetEquipmentTypeDetailQuery, CommandEquipmentType>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetEquipmentTypeDetailQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<CommandEquipmentType> Handle(GetEquipmentTypeDetailQuery request, CancellationToken cancellationToken)
        {
            var table = await _UnitOfWork.RepositoryEquipmentType.GetByIdAsync(request.Id);
            var dto = _mapper.Map<CommandEquipmentType>(table);
            return dto;
        }
    }
}
