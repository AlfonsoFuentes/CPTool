using AutoMapper;

using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;

using MediatR;
using CPTool.ApplicationCQRSFeatures.EquipmentTypeSubs.Queries.GetList;
using CPTool.ApplicationCQRS.Features.EquipmentTypeSubs.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRSFeatures.EquipmentTypeSubs.Queries.GetList
{
    public class GetEquipmentTypeSubListQueryHandler : IRequestHandler<GetEquipmentTypeSubsListQuery, List<CommandEquipmentTypeSub>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetEquipmentTypeSubListQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<List<CommandEquipmentTypeSub>> Handle(GetEquipmentTypeSubsListQuery request, CancellationToken cancellationToken)
        {
            IReadOnlyList<EquipmentTypeSub> allEquipmentTypeSub = null!;

            if(request.EquipmentTypeId==0)
                allEquipmentTypeSub = await _UnitOfWork.RepositoryEquipmentTypeSub.GetAllAsync();
            else
                allEquipmentTypeSub = await _UnitOfWork.RepositoryEquipmentTypeSub.GetAllAsync(x=>x.EquipmentTypeId== request.EquipmentTypeId);


            return _mapper.Map<List<CommandEquipmentTypeSub>>(allEquipmentTypeSub);
        }
    }
}
