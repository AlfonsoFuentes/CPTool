using CPTool.Application.Features.DeviceFunctionModifierFeatures.CreateEdit;


namespace CPTool.Application.Features.DeviceFunctionModifierFeatures
{
    internal class AddEditDeviceFunctionModifierHandler : CommandHandler<EditDeviceFunctionModifier, AddDeviceFunctionModifier, DeviceFunctionModifier>, IRequestHandler<EditDeviceFunctionModifier, Result<int>>
    {

        public AddEditDeviceFunctionModifierHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeleteDeviceFunctionModifierHandler : DeleteCommandHandler<EditDeviceFunctionModifier, DeviceFunctionModifier>, IRequestHandler<DeleteCommand<EditDeviceFunctionModifier>, IResult>
    {

        public DeleteDeviceFunctionModifierHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListDeviceFunctionModifierHandler : QueryListHandler<EditDeviceFunctionModifier, DeviceFunctionModifier>, IRequestHandler<QueryList<EditDeviceFunctionModifier>, List<EditDeviceFunctionModifier>>
    {

        public GetListDeviceFunctionModifierHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }
        public override async Task<List<EditDeviceFunctionModifier>> Handle(QueryList<EditDeviceFunctionModifier> request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.RepositoryDeviceFunctionModifier.GetAllAsync();

            return _mapper.Map<List<EditDeviceFunctionModifier>>(list);

        }
    }
    internal class QueryIdDeviceFunctionModifierHandler : QueryIdHandler<EditDeviceFunctionModifier, DeviceFunctionModifier>, IRequestHandler<QueryId<EditDeviceFunctionModifier>, EditDeviceFunctionModifier>

    {


        public QueryIdDeviceFunctionModifierHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }
        public override async Task<EditDeviceFunctionModifier> Handle(QueryId<EditDeviceFunctionModifier> request, CancellationToken cancellationToken)
        {
            EditDeviceFunctionModifier result = new();
            if (request.Id != 0)
            {
                var table2 = await _unitofwork.RepositoryDeviceFunctionModifier.GetByIdAsync(request.Id);


                result = _mapper.Map<EditDeviceFunctionModifier>(table2);
            }

            return result;

        }
    }
    internal class QueryExcelDeviceFunctionModifierHandler : QueryExcelHandler<EditDeviceFunctionModifier>, IRequestHandler<QueryExcel<EditDeviceFunctionModifier>, QueryExcel<EditDeviceFunctionModifier>>

    {


        public QueryExcelDeviceFunctionModifierHandler(IMapper mapper, IUnitOfWork unitofwork, IExcelService excelService) : base(unitofwork, mapper, excelService)
        { }

    }
}
