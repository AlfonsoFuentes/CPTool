using CPTool.Application.Features.ContingencyItemFeatures.CreateEdit;

namespace CPTool.Application.Features.ContingencyItemFeatures.Query.GetById
{
    
    //public class GetByIdContingencyItemQuery : GetByIdQuery, IRequest<Edit>
    //{
    //}
    //public class GetByIdContingencyItemQueryHandler : IRequestHandler<GetByIdContingencyItemQuery, AddEditContingencyItem>
    //{

    //    private readonly IMapper _mapper;
    //    private IUnitOfWork _unitofwork;
    //    public GetByIdContingencyItemQueryHandler(IUnitOfWork unitofwork,
    //        IMapper mapper)
    //    {
    //        _unitofwork = unitofwork;
    //        _mapper = mapper;
    //    }
    //    public async Task<AddEditContingencyItem> Handle(GetByIdContingencyItemQuery request, CancellationToken cancellationToken)
    //    {
    //        var table = await _unitofwork.Repository<ContingencyItem>().GetByIdAsync(request.Id);

    //        return _mapper.Map<AddEditContingencyItem>(table);

    //    }
    //}
    
}
