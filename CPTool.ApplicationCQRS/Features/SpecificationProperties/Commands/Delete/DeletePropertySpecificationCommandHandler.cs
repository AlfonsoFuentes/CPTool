using AutoMapper;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Exceptions;
using CPTool.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CPTool.ApplicationCQRSFeatures.PropertySpecifications.Commands.Delete
{
    public class DeletePropertySpecificationCommandHandler : IRequestHandler<DeletePropertySpecificationCommand, DeletePropertySpecificationCommandResponse>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public DeletePropertySpecificationCommandHandler(IMapper mapper, IUnitOfWork UnitOfWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitOfWork;
        }

        public async Task<DeletePropertySpecificationCommandResponse> Handle(DeletePropertySpecificationCommand request, CancellationToken cancellationToken)
        {
            var ToDelete = await _UnitOfWork.RepositoryPropertySpecification.FindAsync(request.Id);
            DeletePropertySpecificationCommandResponse result = new();

            if (ToDelete == null)
            {
                result.Success = false;
                result.Message = $"{nameof(PropertySpecification)} id: {request.Id} doesn't exist";
            }
            if(result.Success)
            {
                try
                {
                    ToDelete!.AddDomainEvent(new DeletedEvent<PropertySpecification>(ToDelete));
                    await _UnitOfWork.RepositoryPropertySpecification.DeleteAsync(ToDelete!);
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
