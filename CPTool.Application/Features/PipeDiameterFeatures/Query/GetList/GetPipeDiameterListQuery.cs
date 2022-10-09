
using AutoMapper;
using CPTool.Application.Features.PipeDiameterFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.PipeDiameterFeatures.Query.GetList
{

    public class GetPipeDiameterListQuery : GetListQuery, IRequest<List<AddEditPipeDiameterCommand>>
    {



    }
    public class GetPipeDiameterListQueryHandler : IRequestHandler<GetPipeDiameterListQuery, List<AddEditPipeDiameterCommand>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetPipeDiameterListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<AddEditPipeDiameterCommand>> Handle(GetPipeDiameterListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<PipeDiameter>().GetAllAsync();

            try
            {
                return _mapper.Map<List<AddEditPipeDiameterCommand>>(list);
            }
            catch (AutoMapperMappingException ex)
            {
                string exm = ex.Message;
                return null!;
            }

        }
    }
}
