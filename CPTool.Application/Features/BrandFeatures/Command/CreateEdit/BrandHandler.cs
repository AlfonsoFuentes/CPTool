namespace CPTool.Application.Features.BrandFeatures.CreateEdit
{
    internal class BrandHandler : AddEditBaseHandler<AddBrand,EditBrand, Brand>, IRequestHandler<EditBrand, Result<int>>
    {

        public BrandHandler(IUnitOfWork unitofwork, IMapper mapper,  ILogger<EditBrand> logger)
            : base(unitofwork, mapper, logger)
        {

        }


    }
}
