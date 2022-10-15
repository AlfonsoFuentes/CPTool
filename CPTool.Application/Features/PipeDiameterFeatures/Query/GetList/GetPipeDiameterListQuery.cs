
using AutoMapper;
using CPTool.Application.Features.PipeDiameterFeatures.CreateEdit;

namespace CPTool.Application.Features.PipeDiameterFeatures.Query.GetList
{

    public class GetPipeDiameterListQuery : GetListQuery, IRequest<List<EditPipeDiameter>>
    {



    }
    public class GetPipeDiameterListQueryHandler : IRequestHandler<GetPipeDiameterListQuery, List<EditPipeDiameter>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetPipeDiameterListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<EditPipeDiameter>> Handle(GetPipeDiameterListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<PipeDiameter>().GetAllAsync();

            try
            {
                return _mapper.Map<List<EditPipeDiameter>>(list);
            }
            catch (AutoMapperMappingException ex)
            {
                string exm = ex.Message;
                return null!;
            }

        }
    }
}
