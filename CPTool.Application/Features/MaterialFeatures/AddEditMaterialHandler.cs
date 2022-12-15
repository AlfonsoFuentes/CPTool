using CPTool.Application.Features.MaterialFeatures.CreateEdit;


namespace CPTool.Application.Features.MaterialFeatures
{
    internal class AddEditMaterialHandler : CommandHandler<EditMaterial, AddMaterial, Material>, IRequestHandler<EditMaterial, Result<int>>
    {

        public AddEditMaterialHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeleteMaterialHandler : DeleteCommandHandler<EditMaterial, Material>, IRequestHandler<DeleteCommand<EditMaterial>, IResult>
    {

        public DeleteMaterialHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListMaterialHandler : QueryListHandler<EditMaterial, Material>, IRequestHandler<QueryList<EditMaterial>, List<EditMaterial>>
    {

        public GetListMaterialHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }
        public override async Task<List<EditMaterial>> Handle(QueryList<EditMaterial> request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.RepositoryMaterial.GetAllAsync();

            return _mapper.Map<List<EditMaterial>>(list);

        }
    }
    internal class QueryIdMaterialHandler : QueryIdHandler<EditMaterial, Material>, IRequestHandler<QueryId<EditMaterial>, EditMaterial>

    {


        public QueryIdMaterialHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }
        public override async Task<EditMaterial> Handle(QueryId<EditMaterial> request, CancellationToken cancellationToken)
        {
            EditMaterial result = new();
            if (request.Id != 0)
            {
                var table2 = await _unitofwork.RepositoryMaterial.GetByIdAsync(request.Id);


                result = _mapper.Map<EditMaterial>(table2);
            }

            return result;

        }
    }
    internal class QueryExcelMaterialHandler : QueryExcelHandler<EditMaterial>, IRequestHandler<QueryExcel<EditMaterial>, QueryExcel<EditMaterial>>

    {


        public QueryExcelMaterialHandler(IMapper mapper, IUnitOfWork unitofwork, IExcelService excelService) : base(unitofwork, mapper, excelService)
        { }

    }
}
