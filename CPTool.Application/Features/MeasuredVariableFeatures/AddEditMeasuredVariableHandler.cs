using CPTool.Application.Features.MeasuredVariableFeatures.CreateEdit;


namespace CPTool.Application.Features.MeasuredVariableFeatures
{
    internal class AddEditMeasuredVariableHandler : CommandHandler<EditMeasuredVariable, AddMeasuredVariable, MeasuredVariable>, 
        IRequestHandler<EditMeasuredVariable, Result<int>>
    {

        public AddEditMeasuredVariableHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeleteMeasuredVariableHandler : DeleteCommandHandler<EditMeasuredVariable, MeasuredVariable>, IRequestHandler<DeleteCommand<EditMeasuredVariable>, IResult>
    {

        public DeleteMeasuredVariableHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListMeasuredVariableHandler : QueryListHandler<EditMeasuredVariable, MeasuredVariable>, IRequestHandler<QueryList<EditMeasuredVariable>, List<EditMeasuredVariable>>
    {

        public GetListMeasuredVariableHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }
        public override async Task<List<EditMeasuredVariable>> Handle(QueryList<EditMeasuredVariable> request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.RepositoryMeasuredVariable.GetAllAsync();

            return _mapper.Map<List<EditMeasuredVariable>>(list);

        }
    }
    internal class QueryIdMeasuredVariableHandler : QueryIdHandler<EditMeasuredVariable, MeasuredVariable>, IRequestHandler<QueryId<EditMeasuredVariable>, EditMeasuredVariable>

    {


        public QueryIdMeasuredVariableHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }
        public override async Task<EditMeasuredVariable> Handle(QueryId<EditMeasuredVariable> request, CancellationToken cancellationToken)
        {
            EditMeasuredVariable result = new();
            if (request.Id != 0)
            {
                var table2 = await _unitofwork.RepositoryMeasuredVariable.GetByIdAsync(request.Id);


                result = _mapper.Map<EditMeasuredVariable>(table2);
            }

            return result;

        }
    }
    internal class QueryExcelMeasuredVariableHandler : QueryExcelHandler<EditMeasuredVariable>, IRequestHandler<QueryExcel<EditMeasuredVariable>, QueryExcel<EditMeasuredVariable>>

    {


        public QueryExcelMeasuredVariableHandler(IMapper mapper, IUnitOfWork unitofwork, IExcelService excelService) : base(unitofwork, mapper, excelService)
        { }

    }
}
