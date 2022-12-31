using AutoMapper;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Exceptions;
using CPTool.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CPTool.ApplicationCQRSFeatures.MWOTypes.Commands.Delete
{
    public class DeleteMWOTypeCommandHandler : IRequestHandler<DeleteMWOTypeCommand, DeleteMWOTypeCommandResponse>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public DeleteMWOTypeCommandHandler(IMapper mapper, IUnitOfWork UnitOfWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitOfWork;
        }

        public async Task<DeleteMWOTypeCommandResponse> Handle(DeleteMWOTypeCommand request, CancellationToken cancellationToken)
        {
            var ToDelete = await _UnitOfWork.RepositoryMWOType.FindAsync(request.Id);
            DeleteMWOTypeCommandResponse result = new();

            if (ToDelete == null)
            {
                result.Success = false;
                result.Message = $"{nameof(MWOType)} id: {request.Id} doesn't exist";
            }
            if(result.Success)
            {
                try
                {
                    ToDelete!.AddDomainEvent(new DeletedEvent<MWOType>(ToDelete));
                    await _UnitOfWork.RepositoryMWOType.DeleteAsync(ToDelete!);
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
