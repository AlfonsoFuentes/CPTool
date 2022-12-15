using CPTool.Application.Features.PropertyPackageFeatures.CreateEdit;


namespace CPTool.Application.Features.PropertyPackageFeatures
{
    internal class AddEditPropertyPackageHandler : CommandHandler<EditPropertyPackage, AddPropertyPackage, PropertyPackage>, IRequestHandler<EditPropertyPackage, Result<int>>
    {

        public AddEditPropertyPackageHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeletePropertyPackageHandler : DeleteCommandHandler<EditPropertyPackage, PropertyPackage>, IRequestHandler<DeleteCommand<EditPropertyPackage>, IResult>
    {

        public DeletePropertyPackageHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListPropertyPackageHandler : QueryListHandler<EditPropertyPackage, PropertyPackage>, IRequestHandler<QueryList<EditPropertyPackage>, List<EditPropertyPackage>>
    {

        public GetListPropertyPackageHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }
        public override async Task<List<EditPropertyPackage>> Handle(QueryList<EditPropertyPackage> request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.RepositoryPropertyPackage.GetAllAsync();

            return _mapper.Map<List<EditPropertyPackage>>(list);

        }
    }
    internal class QueryIdPropertyPackageHandler : QueryIdHandler<EditPropertyPackage, PropertyPackage>, IRequestHandler<QueryId<EditPropertyPackage>, EditPropertyPackage>

    {


        public QueryIdPropertyPackageHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }
        public override async Task<EditPropertyPackage> Handle(QueryId<EditPropertyPackage> request, CancellationToken cancellationToken)
        {
            EditPropertyPackage result = new();
            if (request.Id != 0)
            {
                var table2 = await _unitofwork.RepositoryPropertyPackage.GetByIdAsync(request.Id);


                result = _mapper.Map<EditPropertyPackage>(table2);
            }

            return result;

        }
    }
    internal class QueryExcelPropertyPackageHandler : QueryExcelHandler<EditPropertyPackage>, IRequestHandler<QueryExcel<EditPropertyPackage>, QueryExcel<EditPropertyPackage>>

    {


        public QueryExcelPropertyPackageHandler(IMapper mapper, IUnitOfWork unitofwork, IExcelService excelService) : base(unitofwork, mapper, excelService)
        { }

    }
}
