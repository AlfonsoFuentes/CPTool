using CPTool.Application.Features.MaterialFeatures.CreateEdit;


namespace CPTool.Application.Features.MaterialFeatures.Query.GetById
{

    public class GetByIdMaterialQuery : GetByIdQuery, IRequest<EditMaterial>
    {
        public GetByIdMaterialQuery() { }
       
    }
    public class GetByIdMaterialQueryHandler : IRequestHandler<GetByIdMaterialQuery, EditMaterial>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdMaterialQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<EditMaterial> Handle(GetByIdMaterialQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<Material>().GetByIdAsync(request.Id);

            return _mapper.Map<EditMaterial>(table);

        }
    }

}
