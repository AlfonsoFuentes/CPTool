namespace CPTool.Application.Features.MMOTypeFeatures.CreateEdit
{
    internal class MWOTypeHandler : AddEditBaseHandler<AddMWOType,EditMWOType, MWOType>, IRequestHandler<EditMWOType, Result<int>>
    {

        public MWOTypeHandler(IUnitOfWork unitofwork, IMapper mapper, ILogger<EditMWOType> logger) 
            :base(unitofwork, mapper, logger)
        { }



    }

}
