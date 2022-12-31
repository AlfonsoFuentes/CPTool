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

namespace CPTool.ApplicationCQRS.Features.SignalTypes.Commands.CreateUpdate
{
    public class SignalTypeCommandHandler : IRequestHandler<CommandSignalType, SignalTypeCommandResponse>
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;


        public SignalTypeCommandHandler(IMapper mapper, IUnitOfWork unitofwork, IEmailService emailService)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
            _emailService = emailService;
        }

        public async Task<SignalTypeCommandResponse> Handle(CommandSignalType request, CancellationToken cancellationToken)
        {
            var Response = new SignalTypeCommandResponse();

            var validator = new SignalTypeValidator(_unitofwork.RepositorySignalType);
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
                        var addcommand = _mapper.Map<AddSignalType>(request);
                        var table = _mapper.Map<SignalType>(addcommand);
                        table.AddDomainEvent(new CreatedEvent<SignalType>(table));
                        table = await _unitofwork.RepositorySignalType.AddAsync(table);
                        await _unitofwork.Complete();
                        Response.SignalTypeObject = _mapper.Map<CommandSignalType>(table);
                        
                    }
                    else
                    {
                        var table = await _unitofwork.RepositorySignalType.FindAsync(request.Id);
                        if (table != null)
                        {
                            var addcommand = _mapper.Map<AddSignalType>(request);
                            _mapper.Map(addcommand, table, typeof(AddSignalType), typeof(SignalType));
                            table.AddDomainEvent(new UpdatedEvent<SignalType>(table));
                            await _unitofwork.RepositorySignalType.UpdateAsync(table);
                            await _unitofwork.Complete();
                            Response.SignalTypeObject = _mapper.Map<CommandSignalType>(table);
                     
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