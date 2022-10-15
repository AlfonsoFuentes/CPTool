using CPTool.Application.Features.StructuralItemFeatures.CreateEdit;

namespace CPTool.Application.Features.StructuralItemFeatures.Query.GetById
{
    
    //public class GetByIdStructuralItemQuery : GetByIdQuery, IRequest<AddEditStructuralItem>
    //{
    //}
    //public class GetByIdStructuralItemQueryHandler : IRequestHandler<GetByIdStructuralItemQuery, AddEditStructuralItem>
    //{

    //    private readonly IMapper _mapper;
    //    private IUnitOfWork _unitofwork;
    //    public GetByIdStructuralItemQueryHandler(IUnitOfWork unitofwork,
    //        IMapper mapper)
    //    {
    //        _unitofwork = unitofwork;
    //        _mapper = mapper;
    //    }
    //    public async Task<AddEditStructuralItem> Handle(GetByIdStructuralItemQuery request, CancellationToken cancellationToken)
    //    {
    //        var table = await _unitofwork.Repository<StructuralItem>().GetByIdAsync(request.Id);

    //        return _mapper.Map<AddEditStructuralItem>(table);

    //    }
    //}
    
}
