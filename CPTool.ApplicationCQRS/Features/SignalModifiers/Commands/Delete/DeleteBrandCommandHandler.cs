using AutoMapper;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Exceptions;
using CPTool.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CPTool.ApplicationCQRSFeatures.SignalModifiers.Commands.Delete
{
    public class DeleteSignalModifierCommandHandler : IRequestHandler<DeleteSignalModifierCommand, DeleteSignalModifierCommandResponse>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public DeleteSignalModifierCommandHandler(IMapper mapper, IUnitOfWork UnitOfWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitOfWork;
        }

        public async Task<DeleteSignalModifierCommandResponse> Handle(DeleteSignalModifierCommand request, CancellationToken cancellationToken)
        {
            var ToDelete = await _UnitOfWork.RepositorySignalModifier.FindAsync(request.Id);
            DeleteSignalModifierCommandResponse result = new();

            if (ToDelete == null)
            {
                result.Success = false;
                result.Message = $"{nameof(SignalModifier)} id: {request.Id} doesn't exist";
            }
            if(result.Success)
            {
                try
                {
                    ToDelete!.AddDomainEvent(new DeletedEvent<SignalModifier>(ToDelete));
                    await _UnitOfWork.RepositorySignalModifier.DeleteAsync(ToDelete!);
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
