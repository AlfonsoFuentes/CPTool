using AutoMapper;

using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;

using MediatR;
using CPTool.ApplicationCQRSFeatures.EquipmentTypes.Queries.GetList;
using CPTool.ApplicationCQRS.Features.EquipmentTypes.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRSFeatures.EquipmentTypes.Queries.GetList
{
    public class GetEquipmentTypeListQueryHandler : IRequestHandler<GetEquipmentTypesListQuery, List<CommandEquipmentType>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetEquipmentTypeListQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<List<CommandEquipmentType>> Handle(GetEquipmentTypesListQuery request, CancellationToken cancellationToken)
        {
            var list = await _UnitOfWork.RepositoryEquipmentType.GetAllAsync();
            
           
            return _mapper.Map<List<CommandEquipmentType>>(list);
        }
    }
}
