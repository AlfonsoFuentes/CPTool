using CPTool.Application.Features.Base;
using CPTool.Application.Features.ElectricalBoxFeatures.Query.GetById;
using CPTool.Application.Features.ElectricalBoxsFeatures.CreateEdit;
using CPTool.Application.Features.EquipmentItemFeatures.CreateEdit;
using CPTool.Application.Features.InstrumentItemFeatures.CreateEdit;
using CPTool.Application.Features.InstrumentItemFeatures.Query.GetById;

namespace CPTool.Application.Features.EquipmentItemFeatures.Query.GetById
{

    public class GetByIdEquipmentItemQuery : GetByIdQuery, IRequest<EditEquipmentItem>
    {
    }
    public class GetByIdEquipmentItemQueryHandler :
         GetByIdQueryHandler<EditEquipmentItem, EquipmentItem, GetByIdEquipmentItemQuery>,
        IRequestHandler<GetByIdEquipmentItemQuery, EditEquipmentItem>
    {

     
        public GetByIdEquipmentItemQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper):base(unitofwork, mapper)
        {

        }
       
        public override async Task<EditEquipmentItem> Handle(GetByIdEquipmentItemQuery request, CancellationToken cancellationToken)
        {
            EditEquipmentItem retorno = new();
            if (request.Id != 0)
            {
                var table = await _unitofwork.RepositoryEquipmentItem.GetByIdAsync(request.Id);

                retorno = _mapper.Map<EditEquipmentItem>(table);
            }


            return retorno;

        }
    }

}
