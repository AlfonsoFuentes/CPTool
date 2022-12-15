
using CPTool.Application.Features.GasketsFeatures.CreateEdit;
using CPTool.Application.Generic;

namespace CPTool.Application.Features.GasketFeatures
{
    internal class AddEditGasketHandler : CommandHandler<EditGasket, AddGasket, Gasket>, IRequestHandler<EditGasket, Result<int>>
    {

        public AddEditGasketHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeleteGasketHandler : DeleteCommandHandler<EditGasket, Gasket>, IRequestHandler<DeleteCommand<EditGasket>, IResult>
    {

        public DeleteGasketHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListGasketHandler : QueryListHandler<EditGasket, Gasket>, IRequestHandler<QueryList<EditGasket>, List<EditGasket>>
    {

        public GetListGasketHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }
        public override async Task<List<EditGasket>> Handle(QueryList<EditGasket> request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.RepositoryGasket.GetAllAsync();

            return _mapper.Map<List<EditGasket>>(list);

        }
    }
    internal class QueryIdGasketHandler : QueryIdHandler<EditGasket, Gasket>, IRequestHandler<QueryId<EditGasket>, EditGasket>

    {


        public QueryIdGasketHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }
        public override async Task<EditGasket> Handle(QueryId<EditGasket> request, CancellationToken cancellationToken)
        {
            EditGasket result = new();
            if (request.Id != 0)
            {
                var table2 = await _unitofwork.RepositoryGasket.GetByIdAsync(request.Id);


                result = _mapper.Map<EditGasket>(table2);
            }

            return result;

        }
    }
    internal class QueryExcelGasketHandler : QueryExcelHandler<EditGasket>, IRequestHandler<QueryExcel<EditGasket>, QueryExcel<EditGasket>>

    {


        public QueryExcelGasketHandler(IMapper mapper, IUnitOfWork unitofwork, IExcelService excelService) : base(unitofwork, mapper, excelService)
        { }

    }
}
