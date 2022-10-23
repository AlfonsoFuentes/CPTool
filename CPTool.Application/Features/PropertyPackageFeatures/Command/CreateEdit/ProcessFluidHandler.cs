namespace CPTool.Application.Features.PropertyPackageFeatures.CreateEdit
{
    internal class PropertyPackageHandler : AddEditBaseHandler<AddPropertyPackage, EditPropertyPackage, ProcessFluid>, 
        IRequestHandler<EditPropertyPackage, Result<int>>
    {

        public PropertyPackageHandler(IUnitOfWork unitofwork, IMapper mapper, ILogger<EditPropertyPackage> logger)
            : base(unitofwork, mapper,  logger) { }


    }
}
