using CPTool.Application.Features.MWOFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.MWOFeatures.Query.GetList
{

    public class GetMWOListQuery : GetListQuery, IRequest<List<AddEditMWOCommand>>
    {



    }
    public class GetMWOListQueryHandler : IRequestHandler<GetMWOListQuery, List<AddEditMWOCommand>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetMWOListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<AddEditMWOCommand>> Handle(GetMWOListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<MWO>().GetAllAsync();

            return _mapper.Map<List<AddEditMWOCommand>>(list);

        }
    }
}
