using CPTool.Application.Features.MeasuredVariableModifierFeatures.CreateEdit;


namespace CPTool.Application.Features.MeasuredVariableModifierFeatures
{
    internal class AddEditMeasuredVariableModifierHandler : CommandHandler<EditMeasuredVariableModifier, AddMeasuredVariableModifier, MeasuredVariableModifier>,
        IRequestHandler<EditMeasuredVariableModifier, Result<int>>
    {

        public AddEditMeasuredVariableModifierHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeleteMeasuredVariableModifierHandler : DeleteCommandHandler<EditMeasuredVariableModifier, MeasuredVariableModifier>, IRequestHandler<DeleteCommand<EditMeasuredVariableModifier>, IResult>
    {

        public DeleteMeasuredVariableModifierHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListMeasuredVariableModifierHandler : QueryListHandler<EditMeasuredVariableModifier, MeasuredVariableModifier>, IRequestHandler<QueryList<EditMeasuredVariableModifier>, List<EditMeasuredVariableModifier>>
    {

        public GetListMeasuredVariableModifierHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }
        public override async Task<List<EditMeasuredVariableModifier>> Handle(QueryList<EditMeasuredVariableModifier> request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.RepositoryMeasuredVariableModifier.GetAllAsync();

            return _mapper.Map<List<EditMeasuredVariableModifier>>(list);

        }
    }
    internal class QueryIdMeasuredVariableModifierHandler : QueryIdHandler<EditMeasuredVariableModifier, MeasuredVariableModifier>, IRequestHandler<QueryId<EditMeasuredVariableModifier>, EditMeasuredVariableModifier>

    {


        public QueryIdMeasuredVariableModifierHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }
        public override async Task<EditMeasuredVariableModifier> Handle(QueryId<EditMeasuredVariableModifier> request, CancellationToken cancellationToken)
        {
            EditMeasuredVariableModifier result = new();
            if (request.Id != 0)
            {
                var table2 = await _unitofwork.RepositoryMeasuredVariableModifier.GetByIdAsync(request.Id);


                result = _mapper.Map<EditMeasuredVariableModifier>(table2);
            }

            return result;

        }
    }
    internal class QueryExcelMeasuredVariableModifierHandler : QueryExcelHandler<EditMeasuredVariableModifier>, IRequestHandler<QueryExcel<EditMeasuredVariableModifier>, QueryExcel<EditMeasuredVariableModifier>>

    {


        public QueryExcelMeasuredVariableModifierHandler(IMapper mapper, IUnitOfWork unitofwork, IExcelService excelService) : base(unitofwork, mapper, excelService)
        { }

    }
}
