using CPTool.Application.Features.MWOFeatures.CreateEdit;


namespace CPTool.Application.Features.MWOFeatures.Query.GetById
{

    public class GetByIdMWOQuery : GetByIdQuery, IRequest<EditMWO>
    {
        public GetByIdMWOQuery() { }
        
    }
    public class GetByIdMWOQueryHandler : IRequestHandler<GetByIdMWOQuery, EditMWO>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdMWOQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<EditMWO> Handle(GetByIdMWOQuery request, CancellationToken cancellationToken)
        {
           
         
            var table2=await _unitofwork.RepositoryMWO.GetMWO_ItemsIdAsync(request.Id);


            return _mapper.Map<EditMWO>(table2);

        }
    }

}
