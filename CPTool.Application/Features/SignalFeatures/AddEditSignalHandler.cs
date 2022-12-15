
using CPTool.Application.Features.SignalsFeatures.CreateEdit;


namespace CPTool.Application.Features.SignalFeatures
{
    internal class AddEditSignalHandler : CommandHandler<EditSignal, AddSignal, Signal>, IRequestHandler<EditSignal, Result<int>>
    {

        public AddEditSignalHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeleteSignalHandler : DeleteCommandHandler<EditSignal, Signal>, IRequestHandler<DeleteCommand<EditSignal>, IResult>
    {

        public DeleteSignalHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListSignalHandler : QueryListHandler<EditSignal, Signal>, IRequestHandler<QueryList<EditSignal>, List<EditSignal>>
    {

        public GetListSignalHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }
        public override async Task<List<EditSignal>> Handle(QueryList<EditSignal> request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.RepositorySignal.GetAllAsync();

            return _mapper.Map<List<EditSignal>>(list);

        }
    }
    internal class QueryIdSignalHandler : QueryIdHandler<EditSignal, Signal>, IRequestHandler<QueryId<EditSignal>, EditSignal>

    {


        public QueryIdSignalHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }
        public override async Task<EditSignal> Handle(QueryId<EditSignal> request, CancellationToken cancellationToken)
        {
            EditSignal result = new();
            if (request.Id != 0)
            {
                var table2 = await _unitofwork.RepositorySignal.GetByIdAsync(request.Id);


                result = _mapper.Map<EditSignal>(table2);
            }

            return result;

        }
    }
    internal class QueryExcelSignalHandler : QueryExcelHandler<EditSignal>, IRequestHandler<QueryExcel<EditSignal>, QueryExcel<EditSignal>>

    {


        public QueryExcelSignalHandler(IMapper mapper, IUnitOfWork unitofwork, IExcelService excelService) : base(unitofwork, mapper, excelService)
        { }

    }
}
