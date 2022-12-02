using CPTool.Application.Features.DeviceFunctionModifierFeatures.CreateEdit;


namespace CPTool.ApplicationRadzen.Features.DeviceFunctionModifiers
{
    internal class AddEditDeviceFunctionModifierHandler : CommandHandler<EditDeviceFunctionModifier, AddDeviceFunctionModifier, DeviceFunctionModifier>, IRequestHandler<Command<EditDeviceFunctionModifier>, IResult>
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

    }
    internal class QueryIdDeviceFunctionModifierHandler : QueryIdHandler<EditDeviceFunctionModifier, DeviceFunctionModifier>, IRequestHandler<QueryId<EditDeviceFunctionModifier>, EditDeviceFunctionModifier>

    {


        public QueryIdDeviceFunctionModifierHandler(IMapper mapper, IUnitOfWork unitofwork) : base(mapper, unitofwork)
        { }

    }
}
