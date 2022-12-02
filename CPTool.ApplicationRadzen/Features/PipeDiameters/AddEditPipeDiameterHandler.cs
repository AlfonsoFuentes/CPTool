using CPTool.Application.Features.PipeDiameterFeatures.CreateEdit;


namespace CPTool.ApplicationRadzen.Features.PipeDiameters
{
    internal class AddEditPipeDiameterHandler : CommandHandler<EditPipeDiameter, AddPipeDiameter, PipeDiameter>, IRequestHandler<Command<EditPipeDiameter>, IResult>
    {

        public AddEditPipeDiameterHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeletePipeDiameterHandler : DeleteCommandHandler<EditPipeDiameter, PipeDiameter>, IRequestHandler<DeleteCommand<EditPipeDiameter>, IResult>
    {

        public DeletePipeDiameterHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListPipeDiameterHandler : QueryListHandler<EditPipeDiameter, PipeDiameter>, IRequestHandler<QueryList<EditPipeDiameter>, List<EditPipeDiameter>>
    {

        public GetListPipeDiameterHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class QueryIdPipeDiameterHandler : QueryIdHandler<EditPipeDiameter, PipeDiameter>, IRequestHandler<QueryId<EditPipeDiameter>, EditPipeDiameter>

    {


        public QueryIdPipeDiameterHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }

    }
}
