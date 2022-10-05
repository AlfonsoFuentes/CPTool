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
           
         
            var table2=await _unitofwork.RepositoryMWO.GetMWO_ItemsIdAsync(request.Id);


            return _mapper.Map<AddEditMWOCommand>(table2);

        }
    }

}
