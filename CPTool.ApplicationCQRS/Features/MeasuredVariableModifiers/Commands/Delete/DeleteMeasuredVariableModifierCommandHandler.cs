using AutoMapper;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Exceptions;
using CPTool.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CPTool.ApplicationCQRSFeatures.MeasuredVariableModifiers.Commands.Delete
{
    public class DeleteMeasuredVariableModifierCommandHandler : IRequestHandler<DeleteMeasuredVariableModifierCommand, DeleteMeasuredVariableModifierCommandResponse>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public DeleteMeasuredVariableModifierCommandHandler(IMapper mapper, IUnitOfWork UnitOfWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitOfWork;
        }

        public async Task<DeleteMeasuredVariableModifierCommandResponse> Handle(DeleteMeasuredVariableModifierCommand request, CancellationToken cancellationToken)
        {
            var ToDelete = await _UnitOfWork.RepositoryMeasuredVariableModifier.FindAsync(request.Id);
            DeleteMeasuredVariableModifierCommandResponse result = new();

            if (ToDelete == null)
            {
                result.Success = false;
                result.Message = $"{nameof(MeasuredVariableModifier)} id: {request.Id} doesn't exist";
            }
            if(result.Success)
            {
                try
                {
                    ToDelete!.AddDomainEvent(new DeletedEvent<MeasuredVariableModifier>(ToDelete));
                    await _UnitOfWork.RepositoryMeasuredVariableModifier.DeleteAsync(ToDelete!);
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
