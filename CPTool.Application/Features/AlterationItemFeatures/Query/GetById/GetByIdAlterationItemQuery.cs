using CPTool.Application.Features.AlterationItemFeatures.CreateEdit;


namespace CPTool.Application.Features.AlterationItemFeatures.Query.GetById
{

    //public class GetByIdAlterationItemQuery : GetByIdQuery, IRequest<EditAlterationItem>
    //{
    //    public GetByIdAlterationItemQuery(int id) : base(id)
    //    {
    //    }
    //}
    //public class GetByIdAlterationItemQueryHandler : IRequestHandler<GetByIdAlterationItemQuery, EditAlterationItem>
    //{

    //    private readonly IMapper _mapper;
    //    private IUnitOfWork _unitofwork;
    //    public GetByIdAlterationItemQueryHandler(IUnitOfWork unitofwork,
    //        IMapper mapper)
    //    {
    //        _unitofwork = unitofwork;
    //        _mapper = mapper;
    //    }
    //    public async Task<EditAlterationItem> Handle(GetByIdAlterationItemQuery request, CancellationToken cancellationToken)
    //    {
    //        var table = await _unitofwork.Repository<AlterationItem>().GetByIdAsync(request.Id);

    //        return _mapper.Map<EditAlterationItem>(table);

    //    }
    //}
    
}
