using AutoMapper;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Exceptions;
using CPTool.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CPTool.ApplicationCQRSFeatures.PurchaseOrders.Commands.Delete
{
    public class DeletePurchaseOrderCommandHandler : IRequestHandler<DeletePurchaseOrderCommand, DeletePurchaseOrderCommandResponse>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public DeletePurchaseOrderCommandHandler(IMapper mapper, IUnitOfWork UnitOfWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitOfWork;
        }

        public async Task<DeletePurchaseOrderCommandResponse> Handle(DeletePurchaseOrderCommand request, CancellationToken cancellationToken)
        {
            var ToDelete = await _UnitOfWork.RepositoryPurchaseOrder.FindAsync(request.Id);
            DeletePurchaseOrderCommandResponse result = new();

            if (ToDelete == null)
            {
                result.Success = false;
                result.Message = $"{nameof(PurchaseOrder)} id: {request.Id} doesn't exist";
            }
            if(result.Success)
            {
                try
                {
                    ToDelete!.AddDomainEvent(new DeletedEvent<PurchaseOrder>(ToDelete));
                    await _UnitOfWork.RepositoryPurchaseOrder.DeleteAsync(ToDelete!);
                    await _UnitOfWork.Complete();
                   
                }
                catch(Exception ex)
                {
                    result.Success = false;
                    result.Message = ex.Message;
                }
            }
           

            return result;
        }
    }
}
