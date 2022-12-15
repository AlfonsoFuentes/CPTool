using CPTool.Application.Features.ProcessConditionFeatures.CreateEdit;

namespace CPTool.Application.Features.ProcessConditionFeatures
{
    internal class AddEditProcessConditionHandler : CommandHandler<EditProcessCondition, AddProcessCondition, ProcessCondition>, IRequestHandler<EditProcessCondition, Result<int>>
    {

        public AddEditProcessConditionHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeleteProcessConditionHandler : DeleteCommandHandler<EditProcessCondition, ProcessCondition>, IRequestHandler<DeleteCommand<EditProcessCondition>, IResult>
    {

        public DeleteProcessConditionHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListProcessConditionHandler : QueryListHandler<EditProcessCondition, ProcessCondition>, IRequestHandler<QueryList<EditProcessCondition>, List<EditProcessCondition>>
    {

        public GetListProcessConditionHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }
        public override async Task<List<EditProcessCondition>> Handle(QueryList<EditProcessCondition> request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.RepositoryProcessCondition.GetAllAsync();

            return _mapper.Map<List<EditProcessCondition>>(list);

        }
    }
    internal class QueryIdProcessConditionHandler : QueryIdHandler<EditProcessCondition, ProcessCondition>, IRequestHandler<QueryId<EditProcessCondition>, EditProcessCondition>

    {


        public QueryIdProcessConditionHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }
        public override async Task<EditProcessCondition> Handle(QueryId<EditProcessCondition> request, CancellationToken cancellationToken)
        {
            EditProcessCondition result = new();
            if (request.Id != 0)
            {
                var table2 = await _unitofwork.RepositoryProcessCondition.GetByIdAsync(request.Id);


                result = _mapper.Map<EditProcessCondition>(table2);
            }

            return result;

        }
    }
    internal class QueryExcelProcessConditionHandler : QueryExcelHandler<EditProcessCondition>, IRequestHandler<QueryExcel<EditProcessCondition>, QueryExcel<EditProcessCondition>>

    {


        public QueryExcelProcessConditionHandler(IMapper mapper, IUnitOfWork unitofwork, IExcelService excelService) : base(unitofwork, mapper, excelService)
        { }

    }
}
