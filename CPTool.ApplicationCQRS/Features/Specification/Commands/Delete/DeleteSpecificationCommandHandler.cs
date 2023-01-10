using AutoMapper;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Exceptions;
using CPTool.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CPTool.ApplicationCQRSFeatures.Specifications.Commands.Delete
{
    public class DeleteSpecificationCommandHandler : IRequestHandler<DeleteSpecificationCommand, DeleteSpecificationCommandResponse>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public DeleteSpecificationCommandHandler(IMapper mapper, IUnitOfWork UnitOfWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitOfWork;
        }

        public async Task<DeleteSpecificationCommandResponse> Handle(DeleteSpecificationCommand request, CancellationToken cancellationToken)
        {
            var ToDelete = await _UnitOfWork.RepositorySpecification.FindAsync(request.Id);
            DeleteSpecificationCommandResponse result = new();

            if (ToDelete == null)
            {
                result.Success = false;
                result.Message = $"{nameof(Specification)} id: {request.Id} doesn't exist";
            }
            if(result.Success)
            {
                try
                {
                    ToDelete!.AddDomainEvent(new DeletedEvent<Specification>(ToDelete));
                    await _UnitOfWork.RepositorySpecification.DeleteAsync(ToDelete!);
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
