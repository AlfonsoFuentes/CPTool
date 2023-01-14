using AutoMapper;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Exceptions;
using CPTool.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CPTool.ApplicationCQRSFeatures.UserRequirementTypes.Commands.Delete
{
    public class DeleteUserRequirementTypeCommandHandler : IRequestHandler<DeleteUserRequirementTypeCommand, DeleteUserRequirementTypeCommandResponse>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public DeleteUserRequirementTypeCommandHandler(IMapper mapper, IUnitOfWork UnitOfWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitOfWork;
        }

        public async Task<DeleteUserRequirementTypeCommandResponse> Handle(DeleteUserRequirementTypeCommand request, CancellationToken cancellationToken)
        {
            var ToDelete = await _UnitOfWork.RepositoryUserRequirementType.FindAsync(request.Id);
            DeleteUserRequirementTypeCommandResponse result = new();

            if (ToDelete == null)
            {
                result.Success = false;
                result.Message = $"{nameof(UserRequirementType)} id: {request.Id} doesn't exist";
            }
            if(result.Success)
            {
                try
                {
                    ToDelete!.AddDomainEvent(new DeletedEvent<UserRequirementType>(ToDelete));
                    await _UnitOfWork.RepositoryUserRequirementType.DeleteAsync(ToDelete!);
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
