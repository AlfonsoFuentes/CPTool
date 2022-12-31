using AutoMapper;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Exceptions;
using CPTool.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CPTool.ApplicationCQRSFeatures.DeviceFunctionModifiers.Commands.Delete
{
    public class DeleteDeviceFunctionModifierCommandHandler : IRequestHandler<DeleteDeviceFunctionModifierCommand, DeleteDeviceFunctionModifierCommandResponse>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public DeleteDeviceFunctionModifierCommandHandler(IMapper mapper, IUnitOfWork UnitOfWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitOfWork;
        }

        public async Task<DeleteDeviceFunctionModifierCommandResponse> Handle(DeleteDeviceFunctionModifierCommand request, CancellationToken cancellationToken)
        {
            var ToDelete = await _UnitOfWork.RepositoryDeviceFunctionModifier.FindAsync(request.Id);
            DeleteDeviceFunctionModifierCommandResponse result = new();

            if (ToDelete == null)
            {
                result.Success = false;
                result.Message = $"{nameof(DeviceFunctionModifier)} id: {request.Id} doesn't exist";
            }
            if(result.Success)
            {
                try
                {
                    ToDelete!.AddDomainEvent(new DeletedEvent<DeviceFunctionModifier>(ToDelete));
                    await _UnitOfWork.RepositoryDeviceFunctionModifier.DeleteAsync(ToDelete!);
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
