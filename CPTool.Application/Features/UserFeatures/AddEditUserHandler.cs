using CPTool.Application.Features.UserFeatures.CreateEdit;


namespace CPTool.Application.Features.UserFeature
{
    internal class AddEditUserHandler : CommandHandler<EditUser, AddUser, User>, IRequestHandler<EditUser, Result<int>>
    {

        public AddEditUserHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeleteUserHandler : DeleteCommandHandler<EditUser, User>, IRequestHandler<DeleteCommand<EditUser>, IResult>
    {

        public DeleteUserHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListUserHandler : QueryListHandler<EditUser, User>, IRequestHandler<QueryList<EditUser>, List<EditUser>>
    {

        public GetListUserHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }
        public override async Task<List<EditUser>> Handle(QueryList<EditUser> request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.RepositoryUser.GetAllAsync();

            return _mapper.Map<List<EditUser>>(list);

        }
    }
    internal class QueryIdUserHandler : QueryIdHandler<EditUser, User>, IRequestHandler<QueryId<EditUser>, EditUser>

    {


        public QueryIdUserHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }
        public override async Task<EditUser> Handle(QueryId<EditUser> request, CancellationToken cancellationToken)
        {
            EditUser result = new();
            if (request.Id != 0)
            {
                var table2 = await _unitofwork.RepositoryUser.GetByIdAsync(request.Id);


                result = _mapper.Map<EditUser>(table2);
            }

            return result;

        }
    }
    internal class QueryExcelUserHandler : QueryExcelHandler<EditUser>, IRequestHandler<QueryExcel<EditUser>, QueryExcel<EditUser>>

    {


        public QueryExcelUserHandler(IMapper mapper, IUnitOfWork unitofwork, IExcelService excelService) : base(unitofwork, mapper, excelService)
        { }

    }
}
