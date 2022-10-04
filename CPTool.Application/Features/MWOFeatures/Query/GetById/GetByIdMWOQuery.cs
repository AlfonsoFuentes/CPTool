using CPTool.Application.Features.MWOFeatures.Command.CreateEdit;


namespace CPTool.Application.Features.MWOFeatures.Query.GetById
{

    public class GetByIdMWOQuery : GetByIdQuery, IRequest<AddEditMWOCommand>
    {
    }
    public class GetByIdMWOQueryHandler : IRequestHandler<GetByIdMWOQuery, AddEditMWOCommand>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdMWOQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<AddEditMWOCommand> Handle(GetByIdMWOQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<MWO>().GetByIdAsync(request.Id);

            return _mapper.Map<AddEditMWOCommand>(table);

        }
    }

}
