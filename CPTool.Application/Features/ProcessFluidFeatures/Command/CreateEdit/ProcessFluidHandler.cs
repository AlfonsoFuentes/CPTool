namespace CPTool.Application.Features.ProcessFluidFeatures.CreateEdit
{
    internal class ProcessFluidHandler : AddEditBaseHandler<AddProcessFluid, EditProcessFluid, ProcessFluid>, IRequestHandler<EditProcessFluid, Result<int>>
    {

        public ProcessFluidHandler(IUnitOfWork unitofwork, IMapper mapper, ILogger<EditProcessFluid> logger)
            : base(unitofwork, mapper,  logger) { }


    }
}
