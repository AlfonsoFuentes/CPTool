using CPTool.Application.Features.PipeClassFeatures.CreateEdit;


namespace CPTool.Application.Features.PipeClassFeatures
{
    internal class AddEditPipeClassHandler : CommandHandler<EditPipeClass, AddPipeClass, PipeClass>, IRequestHandler<EditPipeClass, Result<int>>
    {

        public AddEditPipeClassHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeletePipeClassHandler : DeleteCommandHandler<EditPipeClass, PipeClass>, IRequestHandler<DeleteCommand<EditPipeClass>, IResult>
    {

        public DeletePipeClassHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListPipeClassHandler : QueryListHandler<EditPipeClass, PipeClass>, IRequestHandler<QueryList<EditPipeClass>, List<EditPipeClass>>
    {

        public GetListPipeClassHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }
        public override async Task<List<EditPipeClass>> Handle(QueryList<EditPipeClass> request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.RepositoryPipeClass.GetAllAsync();

            return _mapper.Map<List<EditPipeClass>>(list);

        }
    }
    internal class QueryIdPipeClassHandler : QueryIdHandler<EditPipeClass, PipeClass>, IRequestHandler<QueryId<EditPipeClass>, EditPipeClass>

    {


        public QueryIdPipeClassHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }
        public override async Task<EditPipeClass> Handle(QueryId<EditPipeClass> request, CancellationToken cancellationToken)
        {
            EditPipeClass result = new();
            if (request.Id != 0)
            {
                var table2 = await _unitofwork.RepositoryPipeClass.GetByIdAsync(request.Id);


                result = _mapper.Map<EditPipeClass>(table2);
            }

            return result;

        }
    }
    internal class QueryExcelPipeClassHandler : QueryExcelHandler<EditPipeClass>, IRequestHandler<QueryExcel<EditPipeClass>, QueryExcel<EditPipeClass>>

    {


        public QueryExcelPipeClassHandler(IMapper mapper, IUnitOfWork unitofwork, IExcelService excelService) : base(unitofwork, mapper, excelService)
        { }

    }
}
