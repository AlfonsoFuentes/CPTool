namespace CPTool.Application.Features.MMOTypeFeatures.Query.GetById
{
    
    public class GetByIdMWOTypeQuery : GetByIdQuery, IRequest<AddEditMWOTypeCommand>
    {
    }
    public class GetByIdMWOTypeQueryHandler : IRequestHandler<GetByIdMWOTypeQuery, AddEditMWOTypeCommand>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdMWOTypeQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<AddEditMWOTypeCommand> Handle(GetByIdMWOTypeQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<MWOType>().GetByIdAsync(request.Id);

            return _mapper.Map<AddEditMWOTypeCommand>(table);

        }
    }
    
}
