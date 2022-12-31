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

namespace CPTool.ApplicationCQRS.Features.PipingItems.Commands.CreateUpdate
{
    public class PipingItemCommandHandler : IRequestHandler<CommandPipingItem, PipingItemCommandResponse>
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;


        public PipingItemCommandHandler(IMapper mapper, IUnitOfWork unitofwork, IEmailService emailService)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
            _emailService = emailService;
        }

        public async Task<PipingItemCommandResponse> Handle(CommandPipingItem request, CancellationToken cancellationToken)
        {
            var Response = new PipingItemCommandResponse();

            var validator = new PipingItemValidator(_unitofwork.RepositoryPipingItem);
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
                        var addcommand = _mapper.Map<AddPipingItem>(request);
                        var table = _mapper.Map<PipingItem>(addcommand);
                        table.AddDomainEvent(new CreatedEvent<PipingItem>(table));
                        table = await _unitofwork.RepositoryPipingItem.AddAsync(table);
                        await _unitofwork.Complete();
                        Response.PipingItemObject = _mapper.Map<CommandPipingItem>(table);
                        
                    }
                    else
                    {
                        var table = await _unitofwork.RepositoryPipingItem.FindAsync(request.Id);
                        if (table != null)
                        {
                            var addcommand = _mapper.Map<AddPipingItem>(request);
                            _mapper.Map(addcommand, table, typeof(AddPipingItem), typeof(PipingItem));
                            table.AddDomainEvent(new UpdatedEvent<PipingItem>(table));
                            await _unitofwork.RepositoryPipingItem.UpdateAsync(table);
                            await _unitofwork.Complete();
                            Response.PipingItemObject = _mapper.Map<CommandPipingItem>(table);
                     
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