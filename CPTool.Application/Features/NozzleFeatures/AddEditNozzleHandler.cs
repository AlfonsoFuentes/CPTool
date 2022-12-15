using CPTool.Application.Features.NozzleFeatures.CreateEdit;

namespace CPTool.Application.Features.NozzleFeatures
{
    internal class AddEditNozzleHandler : CommandHandler<EditNozzle, AddNozzle, Nozzle>, IRequestHandler<EditNozzle, Result<int>>
    {

        public AddEditNozzleHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeleteNozzleHandler : DeleteCommandHandler<EditNozzle, Nozzle>, IRequestHandler<DeleteCommand<EditNozzle>, IResult>
    {

        public DeleteNozzleHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListNozzleHandler : QueryListHandler<EditNozzle, Nozzle>, IRequestHandler<QueryList<EditNozzle>, List<EditNozzle>>
    {

        public GetListNozzleHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }
        public override async Task<List<EditNozzle>> Handle(QueryList<EditNozzle> request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.RepositoryNozzle.GetAllAsync();

            return _mapper.Map<List<EditNozzle>>(list);

        }
    }
    internal class QueryIdNozzleHandler : QueryIdHandler<EditNozzle, Nozzle>, IRequestHandler<QueryId<EditNozzle>, EditNozzle>

    {


        public QueryIdNozzleHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }
        public override async Task<EditNozzle> Handle(QueryId<EditNozzle> request, CancellationToken cancellationToken)
        {
            EditNozzle result = new();
            if (request.Id != 0)
            {
                var table2 = await _unitofwork.RepositoryNozzle.GetByIdAsync(request.Id);


                result = _mapper.Map<EditNozzle>(table2);
            }

            return result;

        }
    }
    internal class QueryExcelNozzleHandler : QueryExcelHandler<EditNozzle>, IRequestHandler<QueryExcel<EditNozzle>, QueryExcel<EditNozzle>>

    {


        public QueryExcelNozzleHandler(IMapper mapper, IUnitOfWork unitofwork, IExcelService excelService) : base(unitofwork, mapper, excelService)
        { }

    }
}
