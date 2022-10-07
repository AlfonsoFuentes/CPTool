
using CPTool.Application.Features.ReadoutFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.ReadoutFeatures.Query.GetList
{

    public class GetReadoutListQuery : GetListQuery, IRequest<List<AddEditReadoutCommand>>
    {



    }
    public class GetReadoutListQueryHandler : IRequestHandler<GetReadoutListQuery, List<AddEditReadoutCommand>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetReadoutListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<AddEditReadoutCommand>> Handle(GetReadoutListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<Readout>().GetAllAsync();

            return _mapper.Map<List<AddEditReadoutCommand>>(list);

        }
    }
}
