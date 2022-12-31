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

namespace CPTool.ApplicationCQRS.Features.FoundationItems.Commands.CreateUpdate
{
    public class FoundationItemCommandHandler : IRequestHandler<CommandFoundationItem, FoundationItemCommandResponse>
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;


        public FoundationItemCommandHandler(IMapper mapper, IUnitOfWork unitofwork, IEmailService emailService)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
            _emailService = emailService;
        }

        public async Task<FoundationItemCommandResponse> Handle(CommandFoundationItem request, CancellationToken cancellationToken)
        {
            var Response = new FoundationItemCommandResponse();

            var validator = new FoundationItemValidator(_unitofwork.RepositoryFoundationItem);
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
                        var addcommand = _mapper.Map<AddFoundationItem>(request);
                        var table = _mapper.Map<FoundationItem>(addcommand);
                        table.AddDomainEvent(new CreatedEvent<FoundationItem>(table));
                        table = await _unitofwork.RepositoryFoundationItem.AddAsync(table);
                        await _unitofwork.Complete();
                        Response.FoundationItemObject = _mapper.Map<CommandFoundationItem>(table);
                        
                    }
                    else
                    {
                        var table = await _unitofwork.RepositoryFoundationItem.FindAsync(request.Id);
                        if (table != null)
                        {
                            var addcommand = _mapper.Map<AddFoundationItem>(request);
                            _mapper.Map(addcommand, table, typeof(AddFoundationItem), typeof(FoundationItem));
                            table.AddDomainEvent(new UpdatedEvent<FoundationItem>(table));
                            await _unitofwork.RepositoryFoundationItem.UpdateAsync(table);
                            await _unitofwork.Complete();
                            Response.FoundationItemObject = _mapper.Map<CommandFoundationItem>(table);
                     
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