using CPTool.Application.Features.DeviceFunctionFeatures.CreateEdit;


namespace CPTool.Application.Features.DeviceFunctionFeatures
{
    internal class AddEditDeviceFunctionHandler : CommandHandler<EditDeviceFunction, AddDeviceFunction, DeviceFunction>, IRequestHandler<EditDeviceFunction, Result<int>>
    {

        public AddEditDeviceFunctionHandler(IUnitOfWork unitofwork, IMapper mapper)
            : base(unitofwork, mapper)
        { }

    }
    internal class DeleteDeviceFunctionHandler : DeleteCommandHandler<EditDeviceFunction, DeviceFunction>, IRequestHandler<DeleteCommand<EditDeviceFunction>, IResult>
    {

        public DeleteDeviceFunctionHandler(IUnitOfWork unitofwork)
            : base(unitofwork)
        { }

    }
    internal class GetListDeviceFunctionHandler : QueryListHandler<EditDeviceFunction, DeviceFunction>, IRequestHandler<QueryList<EditDeviceFunction>, List<EditDeviceFunction>>
    {

        public GetListDeviceFunctionHandler(IUnitOfWork unitofwork,
            IMapper mapper)
            : base(unitofwork, mapper)
        { }
        public override async Task<List<EditDeviceFunction>> Handle(QueryList<EditDeviceFunction> request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.RepositoryDeviceFunction.GetAllAsync();

            return _mapper.Map<List<EditDeviceFunction>>(list);

        }
    }
    internal class QueryIdDeviceFunctionHandler : QueryIdHandler<EditDeviceFunction, DeviceFunction>, IRequestHandler<QueryId<EditDeviceFunction>, EditDeviceFunction>

    {


        public QueryIdDeviceFunctionHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }
        public override async Task<EditDeviceFunction> Handle(QueryId<EditDeviceFunction> request, CancellationToken cancellationToken)
        {
            EditDeviceFunction result = new();
            if (request.Id != 0)
            {
                var table2 = await _unitofwork.RepositoryDeviceFunction.GetByIdAsync(request.Id);


                result = _mapper.Map<EditDeviceFunction>(table2);
            }

            return result;

        }
    }
    internal class QueryExcelDeviceFunctionHandler : QueryExcelHandler<EditDeviceFunction>, IRequestHandler<QueryExcel<EditDeviceFunction>, QueryExcel<EditDeviceFunction>>

    {


        public QueryExcelDeviceFunctionHandler(IMapper mapper, IUnitOfWork unitofwork, IExcelService excelService) : base(unitofwork, mapper, excelService)
        { }

    }
}
