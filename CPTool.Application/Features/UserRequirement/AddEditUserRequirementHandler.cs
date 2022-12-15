using CPTool.Application.Features.UserRequirementFeatures.CreateEdit;


namespace CPTool.Application.Features.UserRequirementFeatures
{
    internal class AddEditUserRequirementHandler : CommandHandler<EditUserRequirement, AddUserRequirement, UserRequirement>, IRequestHandler<EditUserRequirement, Result<int>>
    {

        public AddEditUserRequirementHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeleteUserRequirementHandler : DeleteCommandHandler<EditUserRequirement, UserRequirement>, IRequestHandler<DeleteCommand<EditUserRequirement>, IResult>
    {

        public DeleteUserRequirementHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListUserRequirementHandler : QueryListHandler<EditUserRequirement, UserRequirement>, IRequestHandler<QueryList<EditUserRequirement>, List<EditUserRequirement>>
    {

        public GetListUserRequirementHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }
        public override async Task<List<EditUserRequirement>> Handle(QueryList<EditUserRequirement> request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.RepositoryUserRequirement.GetAllAsync();

            return _mapper.Map<List<EditUserRequirement>>(list);

        }
    }
    internal class QueryIdUserRequirementHandler : QueryIdHandler<EditUserRequirement, UserRequirement>, IRequestHandler<QueryId<EditUserRequirement>, EditUserRequirement>

    {


        public QueryIdUserRequirementHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }
        public override async Task<EditUserRequirement> Handle(QueryId<EditUserRequirement> request, CancellationToken cancellationToken)
        {
            EditUserRequirement result = new();
            if (request.Id != 0)
            {
                var table2 = await _unitofwork.RepositoryUserRequirement.GetByIdAsync(request.Id);


                result = _mapper.Map<EditUserRequirement>(table2);
            }

            return result;

        }
    }
    internal class QueryExcelUserRequirementHandler : QueryExcelHandler<EditUserRequirement>, IRequestHandler<QueryExcel<EditUserRequirement>, QueryExcel<EditUserRequirement>>

    {


        public QueryExcelUserRequirementHandler(IMapper mapper, IUnitOfWork unitofwork, IExcelService excelService) : base(unitofwork, mapper, excelService)
        { }

    }
}
