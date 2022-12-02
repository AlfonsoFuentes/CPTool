using CPTool.Application.Features.DeviceFunctionFeatures.CreateEdit;


namespace CPTool.ApplicationRadzen.Features.DeviceFunctions
{
    internal class AddEditDeviceFunctionHandler : CommandHandler<EditDeviceFunction, AddDeviceFunction, DeviceFunction>, IRequestHandler<Command<EditDeviceFunction>, IResult>
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

    }
    internal class QueryIdDeviceFunctionHandler : QueryIdHandler<EditDeviceFunction, DeviceFunction>, IRequestHandler<QueryId<EditDeviceFunction>, EditDeviceFunction>

    {


        public QueryIdDeviceFunctionHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }

    }
}
