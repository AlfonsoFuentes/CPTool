using CPTool.Application.Features.EquipmentTypeSubFeatures.CreateEdit;
using CPTool.Application.Features.EquipmentTypeSubFeatures.CreateEdit;
using CPTool.Application.Generic;
using CPTool.Application.Services;

namespace CPTool.Application.Features.EquipmentTypeSubFeatures
{
    internal class AddEditEquipmentTypeSubHandler : CommandHandler<EditEquipmentTypeSub, AddEquipmentTypeSub, EquipmentTypeSub>, IRequestHandler<EditEquipmentTypeSub, Result<int>>
    {

        public AddEditEquipmentTypeSubHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeleteEquipmentTypeSubHandler : DeleteCommandHandler<EditEquipmentTypeSub, EquipmentTypeSub>, IRequestHandler<DeleteCommand<EditEquipmentTypeSub>, IResult>
    {

        public DeleteEquipmentTypeSubHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListEquipmentTypeSubHandler : QueryListHandler<EditEquipmentTypeSub, EquipmentTypeSub>, IRequestHandler<QueryList<EditEquipmentTypeSub>, List<EditEquipmentTypeSub>>
    {

        public GetListEquipmentTypeSubHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }
        public override async Task<List<EditEquipmentTypeSub>> Handle(QueryList<EditEquipmentTypeSub> request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.RepositoryEquipmentTypeSub.GetAllAsync();

            return _mapper.Map<List<EditEquipmentTypeSub>>(list);

        }
    }
    internal class QueryIdEquipmentTypeSubHandler : QueryIdHandler<EditEquipmentTypeSub, EquipmentTypeSub>, IRequestHandler<QueryId<EditEquipmentTypeSub>, EditEquipmentTypeSub>

    {


        public QueryIdEquipmentTypeSubHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }
        public override async Task<EditEquipmentTypeSub> Handle(QueryId<EditEquipmentTypeSub> request, CancellationToken cancellationToken)
        {
            EditEquipmentTypeSub result = new();
            if (request.Id != 0)
            {
                var table2 = await _unitofwork.RepositoryEquipmentTypeSub.GetByIdAsync(request.Id);


                result = _mapper.Map<EditEquipmentTypeSub>(table2);
            }

            return result;

        }
    }
    internal class QueryExcelEquipmentTypeSubHandler : QueryExcelHandler<EditEquipmentTypeSub>, IRequestHandler<QueryExcel<EditEquipmentTypeSub>, QueryExcel<EditEquipmentTypeSub>>

    {


        public QueryExcelEquipmentTypeSubHandler(IMapper mapper, IUnitOfWork unitofwork, IExcelService excelService) : base(unitofwork, mapper, excelService)
        { }

    }
}
