namespace CPTool.Application.Features.MaterialFeatures.CreateEdit
{
    internal class MaterialHandler : AddEditBaseHandler<AddMaterial,EditMaterial, Material>, IRequestHandler<EditMaterial, Result<int>>
    {


        public MaterialHandler(IUnitOfWork unitofwork, IMapper mapper, ILogger<EditMaterial> logger)
            : base(unitofwork, mapper,  logger)
        {

        }

    }
}
