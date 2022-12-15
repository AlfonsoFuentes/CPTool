using CPTool.Application.Features.ReadoutFeatures.CreateEdit;


namespace CPTool.Application.Features.ReadoutFeatures
{
    internal class AddEditReadoutHandler : CommandHandler<EditReadout, AddReadout, Readout>, IRequestHandler<EditReadout, Result<int>>
    {

        public AddEditReadoutHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeleteReadoutHandler : DeleteCommandHandler<EditReadout, Readout>, IRequestHandler<DeleteCommand<EditReadout>, IResult>
    {

        public DeleteReadoutHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListReadoutHandler : QueryListHandler<EditReadout, Readout>, IRequestHandler<QueryList<EditReadout>, List<EditReadout>>
    {

        public GetListReadoutHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }
        public override async Task<List<EditReadout>> Handle(QueryList<EditReadout> request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.RepositoryReadout.GetAllAsync();

            return _mapper.Map<List<EditReadout>>(list);

        }
    }
    internal class QueryIdReadoutHandler : QueryIdHandler<EditReadout, Readout>, IRequestHandler<QueryId<EditReadout>, EditReadout>

    {


        public QueryIdReadoutHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }
        public override async Task<EditReadout> Handle(QueryId<EditReadout> request, CancellationToken cancellationToken)
        {
            EditReadout result = new();
            if (request.Id != 0)
            {
                var table2 = await _unitofwork.RepositoryReadout.GetByIdAsync(request.Id);


                result = _mapper.Map<EditReadout>(table2);
            }

            return result;

        }
    }
    internal class QueryExcelReadoutHandler : QueryExcelHandler<EditReadout>, IRequestHandler<QueryExcel<EditReadout>, QueryExcel<EditReadout>>

    {


        public QueryExcelReadoutHandler(IMapper mapper, IUnitOfWork unitofwork, IExcelService excelService) : base(unitofwork, mapper, excelService)
        { }

    }
}
