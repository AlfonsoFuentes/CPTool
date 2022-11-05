using CPTool.Application.Features.GasketFeatures.Query.GetById;
using CPTool.Application.Features.GasketsFeatures.CreateEdit;
using CPTool.Application.Features.InstrumentItemFeatures.CreateEdit;

namespace CPTool.Application.Features.InstrumentItemFeatures.Query.GetById
{

    public class GetByIdInstrumentItemQuery : GetByIdQuery, IRequest<EditInstrumentItem>
    {
        
    }
    public class GetByIdInstrumentItemQueryHandler : GetByIdQueryHandler<EditInstrumentItem, InstrumentItem, GetByIdInstrumentItemQuery>, 
        IRequestHandler<GetByIdInstrumentItemQuery, EditInstrumentItem>
    {

       
        public GetByIdInstrumentItemQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper):base(unitofwork, mapper)
        {

        }
        public override async Task<EditInstrumentItem> Handle(GetByIdInstrumentItemQuery request, CancellationToken cancellationToken)
        {
            EditInstrumentItem retorno = new();
            if(request.Id!=0)
            {
                var table = await _unitofwork.RepositoryInstrumentItem.GetByIdAsync(request.Id);

                retorno= _mapper.Map<EditInstrumentItem>(table);
            }
          

            return retorno;

        }
    }
    
}
