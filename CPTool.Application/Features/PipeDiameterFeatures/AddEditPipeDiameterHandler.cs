using CPTool.Application.Features.PipeDiameterFeatures.CreateEdit;


namespace CPTool.Application.Features.PipeDiameterFeatures
{
    internal class AddEditPipeDiameterHandler : CommandHandler<EditPipeDiameter, AddPipeDiameter, PipeDiameter>, IRequestHandler<EditPipeDiameter, Result<int>>
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
        public override async Task<List<EditPipeDiameter>> Handle(QueryList<EditPipeDiameter> request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.RepositoryPipeDiameter.GetAllAsync();

            return _mapper.Map<List<EditPipeDiameter>>(list);

        }
    }
    internal class QueryIdPipeDiameterHandler : QueryIdHandler<EditPipeDiameter, PipeDiameter>, IRequestHandler<QueryId<EditPipeDiameter>, EditPipeDiameter>

    {


        public QueryIdPipeDiameterHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }
        public override async Task<EditPipeDiameter> Handle(QueryId<EditPipeDiameter> request, CancellationToken cancellationToken)
        {
            EditPipeDiameter result = new();
            if (request.Id != 0)
            {
                var table2 = await _unitofwork.RepositoryPipeDiameter.GetByIdAsync(request.Id);


                result = _mapper.Map<EditPipeDiameter>(table2);
            }

            return result;

        }
    }
    internal class QueryExcelPipeDiameterHandler : QueryExcelHandler<EditPipeDiameter>, IRequestHandler<QueryExcel<EditPipeDiameter>, QueryExcel<EditPipeDiameter>>

    {


        public QueryExcelPipeDiameterHandler(IMapper mapper, IUnitOfWork unitofwork, IExcelService excelService) : base(unitofwork, mapper, excelService)
        { }

    }
}
