
using CPTool.Application.Features.SignalModifiersFeatures.CreateEdit;

namespace CPTool.Application.Features.SignalModifierFeatures
{
    internal class AddEditSignalModifierHandler : CommandHandler<EditSignalModifier, AddSignalModifier, SignalModifier>, IRequestHandler<EditSignalModifier, Result<int>>
    {

        public AddEditSignalModifierHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeleteSignalModifierHandler : DeleteCommandHandler<EditSignalModifier, SignalModifier>, IRequestHandler<DeleteCommand<EditSignalModifier>, IResult>
    {

        public DeleteSignalModifierHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListSignalModifierHandler : QueryListHandler<EditSignalModifier, SignalModifier>, IRequestHandler<QueryList<EditSignalModifier>, List<EditSignalModifier>>
    {

        public GetListSignalModifierHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }
        public override async Task<List<EditSignalModifier>> Handle(QueryList<EditSignalModifier> request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.RepositorySignalModifier.GetAllAsync();

            return _mapper.Map<List<EditSignalModifier>>(list);

        }
    }
    internal class QueryIdSignalModifierHandler : QueryIdHandler<EditSignalModifier, SignalModifier>, IRequestHandler<QueryId<EditSignalModifier>, EditSignalModifier>

    {


        public QueryIdSignalModifierHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }
        public override async Task<EditSignalModifier> Handle(QueryId<EditSignalModifier> request, CancellationToken cancellationToken)
        {
            EditSignalModifier result = new();
            if (request.Id != 0)
            {
                var table2 = await _unitofwork.RepositorySignalModifier.GetByIdAsync(request.Id);


                result = _mapper.Map<EditSignalModifier>(table2);
            }

            return result;

        }
    }
    internal class QueryExcelSignalModifierHandler : QueryExcelHandler<EditSignalModifier>, IRequestHandler<QueryExcel<EditSignalModifier>, QueryExcel<EditSignalModifier>>

    {


        public QueryExcelSignalModifierHandler(IMapper mapper, IUnitOfWork unitofwork, IExcelService excelService) : base(unitofwork, mapper, excelService)
        { }

    }
}
