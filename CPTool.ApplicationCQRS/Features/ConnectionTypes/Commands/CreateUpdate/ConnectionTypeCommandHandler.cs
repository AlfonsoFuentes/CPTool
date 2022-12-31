using AutoMapper;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Models.Mail;

using MediatR;
using System;
using CPTool.ApplicationCQRS.Exceptions;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.Domain.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using CPTool.Domain.Common;

namespace CPTool.ApplicationCQRS.Features.ConnectionTypes.Commands.CreateUpdate
{
    public class ConnectionTypeCommandHandler : IRequestHandler<CommandConnectionType, ConnectionTypeCommandResponse>
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;


        public ConnectionTypeCommandHandler(IMapper mapper, IUnitOfWork unitofwork, IEmailService emailService)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
            _emailService = emailService;
        }

        public async Task<ConnectionTypeCommandResponse> Handle(CommandConnectionType request, CancellationToken cancellationToken)
        {
            var Response = new ConnectionTypeCommandResponse();

            var validator = new ConnectionTypeValidator(_unitofwork.RepositoryConnectionType);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                Response.Success = false;
                
                foreach (var error in validationResult.Errors)
                {
                    Response.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (Response.Success)
            {
                try
                {
                    if (request.Id == 0)
                    {
                        var addcommand = _mapper.Map<AddConnectionType>(request);
                        var table = _mapper.Map<ConnectionType>(addcommand);
                        table.AddDomainEvent(new CreatedEvent<ConnectionType>(table));
                        table = await _unitofwork.RepositoryConnectionType.AddAsync(table);
                        await _unitofwork.Complete();
                        Response.ConnectionTypeObject = _mapper.Map<CommandConnectionType>(table);
                        
                    }
                    else
                    {
                        var table = await _unitofwork.RepositoryConnectionType.FindAsync(request.Id);
                        if (table != null)
                        {
                            var addcommand = _mapper.Map<AddConnectionType>(request);
                            _mapper.Map(addcommand, table, typeof(AddConnectionType), typeof(ConnectionType));
                            table.AddDomainEvent(new UpdatedEvent<ConnectionType>(table));
                            await _unitofwork.RepositoryConnectionType.UpdateAsync(table);
                            await _unitofwork.Complete();
                            Response.ConnectionTypeObject = _mapper.Map<CommandConnectionType>(table);
                     
                        }


                    }
                }
                catch(Exception ex)
                {
                    Response.Message = ex.Message;
                    Response.Success = false;
                }
                
            }
            var email = new Email() { To = "alfonsofuen@gmail.com", Body = $"A new Mwo Type was created: {request}", Subject = "A new Mwo Type was created" };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                Response.Message = ex.Message;
                //this shouldn't stop the API from doing else so this can be logged
            }


            return Response;
        }
    }
}