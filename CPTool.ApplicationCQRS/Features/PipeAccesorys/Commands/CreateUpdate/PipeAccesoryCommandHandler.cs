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

namespace CPTool.ApplicationCQRS.Features.PipeAccesorys.Commands.CreateUpdate
{
    public class PipeAccesoryCommandHandler : IRequestHandler<CommandPipeAccesory, PipeAccesoryCommandResponse>
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;


        public PipeAccesoryCommandHandler(IMapper mapper, IUnitOfWork unitofwork, IEmailService emailService)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
            _emailService = emailService;
        }

        public async Task<PipeAccesoryCommandResponse> Handle(CommandPipeAccesory request, CancellationToken cancellationToken)
        {
            var Response = new PipeAccesoryCommandResponse();

            var validator = new PipeAccesoryValidator(_unitofwork.RepositoryPipeAccesory);
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
                        var addcommand = _mapper.Map<AddPipeAccesory>(request);
                        var table = _mapper.Map<PipeAccesory>(addcommand);
                        table.AddDomainEvent(new CreatedEvent<PipeAccesory>(table));
                        table = await _unitofwork.RepositoryPipeAccesory.AddAsync(table);
                        await _unitofwork.Complete();
                        Response.PipeAccesoryObject = _mapper.Map<CommandPipeAccesory>(table);
                        
                    }
                    else
                    {
                        var table = await _unitofwork.RepositoryPipeAccesory.FindAsync(request.Id);
                        if (table != null)
                        {
                            var addcommand = _mapper.Map<AddPipeAccesory>(request);
                            _mapper.Map(addcommand, table, typeof(AddPipeAccesory), typeof(PipeAccesory));
                            table.AddDomainEvent(new UpdatedEvent<PipeAccesory>(table));
                            await _unitofwork.RepositoryPipeAccesory.UpdateAsync(table);
                            await _unitofwork.Complete();
                            Response.PipeAccesoryObject = _mapper.Map<CommandPipeAccesory>(table);
                     
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