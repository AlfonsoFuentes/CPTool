using CPTool.Application.Features.TestingItemFeatures.CreateEdit;

namespace CPTool.Application.Features.TestingItemFeatures.Query.GetById
{
    
    //public class GetByIdTestingItemQuery : GetByIdQuery, IRequest<AddEditTestingItem>
    //{
    //}
    //public class GetByIdTestingItemQueryHandler : IRequestHandler<GetByIdTestingItemQuery, AddEditTestingItem>
    //{

    //    private readonly IMapper _mapper;
    //    private IUnitOfWork _unitofwork;
    //    public GetByIdTestingItemQueryHandler(IUnitOfWork unitofwork,
    //        IMapper mapper)
    //    {
    //        _unitofwork = unitofwork;
    //        _mapper = mapper;
    //    }
    //    public async Task<AddEditTestingItem> Handle(GetByIdTestingItemQuery request, CancellationToken cancellationToken)
    //    {
    //        var table = await _unitofwork.Repository<TestingItem>().GetByIdAsync(request.Id);

    //        return _mapper.Map<AddEditTestingItem>(table);

    //    }
    //}
    
}
