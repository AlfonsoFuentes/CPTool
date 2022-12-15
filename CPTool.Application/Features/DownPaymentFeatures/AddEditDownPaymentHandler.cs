using CPTool.Application.Features.DownPaymentFeatures.CreateEdit;


namespace CPTool.Application.Features.DownPaymentFeatures
{
    internal class AddEditDownPaymentHandler : CommandHandler<EditDownPayment, AddDownPayment, DownPayment>, IRequestHandler<EditDownPayment, Result<int>>
    {

        public AddEditDownPaymentHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeleteDownPaymentHandler : DeleteCommandHandler<EditDownPayment, DownPayment>, IRequestHandler<DeleteCommand<EditDownPayment>, IResult>
    {

        public DeleteDownPaymentHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }
        
    }
    internal class GetListDownPaymentHandler : QueryListHandler<EditDownPayment, DownPayment>, IRequestHandler<QueryList<EditDownPayment>, List<EditDownPayment>>
    {

        public GetListDownPaymentHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }
        public override async Task<List<EditDownPayment>> Handle(QueryList<EditDownPayment> request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.RepositoryDownPayment.GetAllAsync();

            return _mapper.Map<List<EditDownPayment>>(list);

        }
    }
    internal class QueryIdDownPaymentHandler : QueryIdHandler<EditDownPayment, DownPayment>, IRequestHandler<QueryId<EditDownPayment>, EditDownPayment>

    {


        public QueryIdDownPaymentHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }

        public override async Task<EditDownPayment> Handle(QueryId<EditDownPayment> request, CancellationToken cancellationToken)
        {
            EditDownPayment result = new();
            if (request.Id != 0)
            {
                var table2 = await _unitofwork.RepositoryDownPayment.GetByIdAsync(request.Id);


                result = _mapper.Map<EditDownPayment>(table2);
            }

            return result;

        }
    }
    internal class QueryExcelDownPaymentHandler : QueryExcelHandler<EditDownPayment>, IRequestHandler<QueryExcel<EditDownPayment>, QueryExcel<EditDownPayment>>

    {


        public QueryExcelDownPaymentHandler(IMapper mapper, IUnitOfWork unitofwork, IExcelService excelService) : base(unitofwork, mapper, excelService)
        { }

    }
}
