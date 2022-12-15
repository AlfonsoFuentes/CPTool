
using CPTool.Application.Features.ElectricalBoxsFeatures.CreateEdit;


namespace CPTool.Application.Features.ElectricalBoxFeatures
{
    internal class AddEditElectricalBoxHandler : CommandHandler<EditElectricalBox, AddElectricalBox, ElectricalBox>, IRequestHandler<EditElectricalBox, Result<int>>
    {

        public AddEditElectricalBoxHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeleteElectricalBoxHandler : DeleteCommandHandler<EditElectricalBox, ElectricalBox>, IRequestHandler<DeleteCommand<EditElectricalBox>, IResult>
    {

        public DeleteElectricalBoxHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListElectricalBoxHandler : QueryListHandler<EditElectricalBox, ElectricalBox>, IRequestHandler<QueryList<EditElectricalBox>, List<EditElectricalBox>>
    {

        public GetListElectricalBoxHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }
        public override async Task<List<EditElectricalBox>> Handle(QueryList<EditElectricalBox> request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.RepositoryElectricalBox.GetAllAsync();

            return _mapper.Map<List<EditElectricalBox>>(list);

        }
    }
    internal class QueryIdElectricalBoxHandler : QueryIdHandler<EditElectricalBox, ElectricalBox>, IRequestHandler<QueryId<EditElectricalBox>, EditElectricalBox>

    {


        public QueryIdElectricalBoxHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }
        public override async Task<EditElectricalBox> Handle(QueryId<EditElectricalBox> request, CancellationToken cancellationToken)
        {
            EditElectricalBox result = new();
            if (request.Id != 0)
            {
                var table2 = await _unitofwork.RepositoryElectricalBox.GetByIdAsync(request.Id);


                result = _mapper.Map<EditElectricalBox>(table2);
            }

            return result;

        }
    }
    internal class QueryExcelElectricalBoxHandler : QueryExcelHandler<EditElectricalBox>, IRequestHandler<QueryExcel<EditElectricalBox>, QueryExcel<EditElectricalBox>>

    {


        public QueryExcelElectricalBoxHandler(IMapper mapper, IUnitOfWork unitofwork, IExcelService excelService) : base(unitofwork, mapper, excelService)
        { }

    }
}
