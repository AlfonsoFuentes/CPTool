using CPTool.Application.Features.DownPaymentFeatures.CreateEdit;


namespace CPTool.ApplicationRadzen.Features.DownPayments
{
    internal class AddEditDownPaymentHandler : CommandHandler<EditDownPayment, AddDownPayment, DownPayment>, IRequestHandler<Command<EditDownPayment>, IResult>
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

    }
    internal class QueryIdDownPaymentHandler : QueryIdHandler<EditDownPayment, DownPayment>, IRequestHandler<QueryId<EditDownPayment>, EditDownPayment>

    {


        public QueryIdDownPaymentHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }

    }
}
