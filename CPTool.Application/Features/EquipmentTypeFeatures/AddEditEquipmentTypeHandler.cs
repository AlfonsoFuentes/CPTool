using CPTool.Application.Features.EquipmentTypeFeatures.CreateEdit;
using CPTool.Application.Features.EquipmentTypeFeatures.CreateEdit;
using CPTool.Application.Generic;
using CPTool.Application.Services;

namespace CPTool.Application.Features.EquipmentTypeFeatures
{
    internal class AddEditEquipmentTypeHandler : CommandHandler<EditEquipmentType, AddEquipmentType, EquipmentType>, IRequestHandler<EditEquipmentType, Result<int>>
    {

        public AddEditEquipmentTypeHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeleteEquipmentTypeHandler : DeleteCommandHandler<EditEquipmentType, EquipmentType>, IRequestHandler<DeleteCommand<EditEquipmentType>, IResult>
    {

        public DeleteEquipmentTypeHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListEquipmentTypeHandler : QueryListHandler<EditEquipmentType, EquipmentType>, IRequestHandler<QueryList<EditEquipmentType>, List<EditEquipmentType>>
    {

        public GetListEquipmentTypeHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }
        public override async Task<List<EditEquipmentType>> Handle(QueryList<EditEquipmentType> request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.RepositoryEquipmentType.GetAllAsync();

            return _mapper.Map<List<EditEquipmentType>>(list);

        }
    }
    internal class QueryIdEquipmentTypeHandler : QueryIdHandler<EditEquipmentType, EquipmentType>, IRequestHandler<QueryId<EditEquipmentType>, EditEquipmentType>

    {


        public QueryIdEquipmentTypeHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }
        public override async Task<EditEquipmentType> Handle(QueryId<EditEquipmentType> request, CancellationToken cancellationToken)
        {
            EditEquipmentType result = new();
            if (request.Id != 0)
            {
                var table2 = await _unitofwork.RepositoryEquipmentType.GetByIdAsync(request.Id);


                result = _mapper.Map<EditEquipmentType>(table2);
            }

            return result;

        }
    }
    internal class QueryExcelEquipmentTypeHandler : QueryExcelHandler<EditEquipmentType>, IRequestHandler<QueryExcel<EditEquipmentType>, QueryExcel<EditEquipmentType>>

    {


        public QueryExcelEquipmentTypeHandler(IMapper mapper, IUnitOfWork unitofwork, IExcelService excelService) : base(unitofwork, mapper, excelService)
        { }

    }
}
