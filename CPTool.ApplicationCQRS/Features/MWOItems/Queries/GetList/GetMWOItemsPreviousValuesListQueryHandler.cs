using AutoMapper;

using MediatR;
using CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate;
using System.Linq.Expressions;
using CPTool.ApplicationCQRS.Common;

namespace CPTool.ApplicationCQRSFeatures.MWOItems.Queries.GetList
{
    public class GetMWOItemsPreviousValuesListQueryHandler : IRequestHandler<GetMWOItemsPreviousValuesListQuery, List<CommandMWOItem>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetMWOItemsPreviousValuesListQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<List<CommandMWOItem>> Handle(GetMWOItemsPreviousValuesListQuery request, CancellationToken cancellationToken)
        {

            Func<IQueryable<MWOItem>, IOrderedQueryable<MWOItem>> orderBy = x => x.OrderBy(x => x.BudgetPrize);

            Expression<Func<MWOItem, bool>> predicate = x => x.MWOId != request.CurrentMWOId && x.BudgetItem == false && x.Existing == false;

            if (request.BrandId != 0)
                predicate = predicate.And(x => x.BrandId == request.BrandId);
            if (request.SupplierId != 0)
                predicate = predicate.And(x => x.SupplierId == request.SupplierId);
            if (request.InnerMaterialId != 0)
                predicate = predicate.And(x => x.InnerMaterialId == request.InnerMaterialId);
            if (request.OuterMaterialId != 0)
                predicate = predicate.And(x => x.MaterialOuterId == request.OuterMaterialId);
            if (request.EquipmentTypeId != 0)
                predicate = predicate.And(x => x.EquipmentTypeId == request.EquipmentTypeId);
            if (request.EquipmentTypeSubId != 0)
                predicate = predicate.And(x => x.EquipmentTypeSubId == request.EquipmentTypeSubId);
            if (request.MeasuredVariableId != 0)
                predicate = predicate.And(x => x.MeasuredVariableId == request.MeasuredVariableId);
            if (request.MeasuredVariableModifierId != 0)
                predicate = predicate.And(x => x.MeasuredVariableModifierId == request.MeasuredVariableModifierId);
            if (request.DeviceFunctionId != 0)
                predicate = predicate.And(x => x.DeviceFunctionId == request.DeviceFunctionId);
            if (request.ReadoutId != 0)
                predicate = predicate.And(x => x.ReadoutId == request.ReadoutId);
            if (request.DeviceFunctionModifierId != 0)
                predicate = predicate.And(x => x.DeviceFunctionModifierId == request.DeviceFunctionModifierId);



            var allMWOItem = (await _UnitOfWork.RepositoryMWOItem.GetAllAsync(predicate, orderBy));



            var result = _mapper.Map<List<CommandMWOItem>>(allMWOItem);


            return result;
        }

    }

}
