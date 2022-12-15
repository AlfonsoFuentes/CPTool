using CPTool.Application.Features.ProcessFluidFeatures.CreateEdit;


namespace CPTool.Application.Features.ProcessFluidFeatures
{
    internal class AddEditProcessFluidHandler : CommandHandler<EditProcessFluid, AddProcessFluid, ProcessFluid>, IRequestHandler<EditProcessFluid, Result<int>>
    {

        public AddEditProcessFluidHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeleteProcessFluidHandler : DeleteCommandHandler<EditProcessFluid, ProcessFluid>, IRequestHandler<DeleteCommand<EditProcessFluid>, IResult>
    {

        public DeleteProcessFluidHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListProcessFluidHandler : QueryListHandler<EditProcessFluid, ProcessFluid>, IRequestHandler<QueryList<EditProcessFluid>, List<EditProcessFluid>>
    {

        public GetListProcessFluidHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }
        public override async Task<List<EditProcessFluid>> Handle(QueryList<EditProcessFluid> request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.RepositoryProcessFluid.GetAllAsync();

            return _mapper.Map<List<EditProcessFluid>>(list);

        }
    }
    internal class QueryIdProcessFluidHandler : QueryIdHandler<EditProcessFluid, ProcessFluid>, IRequestHandler<QueryId<EditProcessFluid>, EditProcessFluid>

    {


        public QueryIdProcessFluidHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }
        public override async Task<EditProcessFluid> Handle(QueryId<EditProcessFluid> request, CancellationToken cancellationToken)
        {
            EditProcessFluid result = new();
            if (request.Id != 0)
            {
                var table2 = await _unitofwork.RepositoryProcessFluid.GetByIdAsync(request.Id);


                result = _mapper.Map<EditProcessFluid>(table2);
            }

            return result;

        }
    }
    internal class QueryExcelProcessFluidHandler : QueryExcelHandler<EditProcessFluid>, IRequestHandler<QueryExcel<EditProcessFluid>, QueryExcel<EditProcessFluid>>

    {


        public QueryExcelProcessFluidHandler(IMapper mapper, IUnitOfWork unitofwork, IExcelService excelService) : base(unitofwork, mapper, excelService)
        { }

    }
}
