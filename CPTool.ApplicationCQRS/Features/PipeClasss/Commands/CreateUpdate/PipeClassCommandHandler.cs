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

namespace CPTool.ApplicationCQRS.Features.PipeClasss.Commands.CreateUpdate
{
    public class PipeClassCommandHandler : IRequestHandler<CommandPipeClass, PipeClassCommandResponse>
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;


        public PipeClassCommandHandler(IMapper mapper, IUnitOfWork unitofwork, IEmailService emailService)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
            _emailService = emailService;
        }

        public async Task<PipeClassCommandResponse> Handle(CommandPipeClass request, CancellationToken cancellationToken)
        {
            var Response = new PipeClassCommandResponse();

            var validator = new PipeClassValidator(_unitofwork.RepositoryPipeClass);
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
                        var addcommand = _mapper.Map<AddPipeClass>(request);
                        var table = _mapper.Map<PipeClass>(addcommand);
                        table.AddDomainEvent(new CreatedEvent<PipeClass>(table));
                        table = await _unitofwork.RepositoryPipeClass.AddAsync(table);
                        await _unitofwork.Complete();
                        Response.PipeClassObject = _mapper.Map<CommandPipeClass>(table);
                        
                    }
                    else
                    {
                        var table = await _unitofwork.RepositoryPipeClass.FindAsync(request.Id);
                        if (table != null)
                        {
                            var addcommand = _mapper.Map<AddPipeClass>(request);
                            _mapper.Map(addcommand, table, typeof(AddPipeClass), typeof(PipeClass));
                            table.AddDomainEvent(new UpdatedEvent<PipeClass>(table));
                            await _unitofwork.RepositoryPipeClass.UpdateAsync(table);
                            await _unitofwork.Complete();
                            Response.PipeClassObject = _mapper.Map<CommandPipeClass>(table);
                     
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