using CPTool.Application.Features.BrandFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.BrandFeatures.Query.GetById
{
    public class GetByIdBrandQuery : GetByIdQuery, IRequest<AddEditBrandCommand>
    {
    }
    public class GetByIdBrandQueryHandler : IRequestHandler<GetByIdBrandQuery, AddEditBrandCommand>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdBrandQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<AddEditBrandCommand> Handle(GetByIdBrandQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<Brand>().GetByIdAsync(request.Id);

            return _mapper.Map<AddEditBrandCommand>(table);

        }
    }
    
}
