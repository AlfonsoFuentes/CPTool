using CPTool.Application.Features.UserRequirementTypeFeatures.CreateEdit;


namespace CPTool.Application.Features.UserRequiremenType
{
    internal class AddEditUserRequirementTypeHandler : CommandHandler<EditUserRequirementType, AddUserRequirementType, UserRequirementType>, IRequestHandler<EditUserRequirementType, Result<int>>
    {

        public AddEditUserRequirementTypeHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeleteUserRequirementTypeHandler : DeleteCommandHandler<EditUserRequirementType, UserRequirementType>, IRequestHandler<DeleteCommand<EditUserRequirementType>, IResult>
    {

        public DeleteUserRequirementTypeHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListUserRequirementTypeHandler : QueryListHandler<EditUserRequirementType, UserRequirementType>, IRequestHandler<QueryList<EditUserRequirementType>, List<EditUserRequirementType>>
    {

        public GetListUserRequirementTypeHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }
        public override async Task<List<EditUserRequirementType>> Handle(QueryList<EditUserRequirementType> request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.RepositoryUserRequirementType.GetAllAsync();

            return _mapper.Map<List<EditUserRequirementType>>(list);

        }
    }
    internal class QueryIdUserRequirementTypeHandler : QueryIdHandler<EditUserRequirementType, UserRequirementType>, IRequestHandler<QueryId<EditUserRequirementType>, EditUserRequirementType>

    {


        public QueryIdUserRequirementTypeHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }
        public override async Task<EditUserRequirementType> Handle(QueryId<EditUserRequirementType> request, CancellationToken cancellationToken)
        {
            EditUserRequirementType result = new();
            if (request.Id != 0)
            {
                var table2 = await _unitofwork.RepositoryUserRequirementType.GetByIdAsync(request.Id);


                result = _mapper.Map<EditUserRequirementType>(table2);
            }

            return result;

        }
    }
    internal class QueryExcelUserRequirementTypeHandler : QueryExcelHandler<EditUserRequirementType>, IRequestHandler<QueryExcel<EditUserRequirementType>, QueryExcel<EditUserRequirementType>>

    {


        public QueryExcelUserRequirementTypeHandler(IMapper mapper, IUnitOfWork unitofwork, IExcelService excelService) : base(unitofwork, mapper, excelService)
        { }

    }
}
