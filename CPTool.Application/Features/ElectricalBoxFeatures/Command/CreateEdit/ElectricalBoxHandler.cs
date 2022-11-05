namespace CPTool.Application.Features.ElectricalBoxsFeatures.CreateEdit
{
    internal class ElectricalBoxHandler : AddEditBaseHandler<AddElectricalBox,EditElectricalBox, ElectricalBox>, IRequestHandler<EditElectricalBox, Result<int>>
    {


        public ElectricalBoxHandler(IUnitOfWork unitofwork, IMapper mapper, ILogger<EditElectricalBox> logger) 
            : base(unitofwork, mapper,  logger)
        {

        }


    }
}