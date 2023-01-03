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
using FluentValidation;

namespace CPTool.ApplicationCQRS.Features.InstrumentItems.Commands.CreateUpdate
{
    public class InstrumentItemCommandHandler : IRequestHandler<CommandInstrumentItem, InstrumentItemCommandResponse>
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;


        public InstrumentItemCommandHandler(IMapper mapper, IUnitOfWork unitofwork, IEmailService emailService)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
            _emailService = emailService;
        }

        public async Task<InstrumentItemCommandResponse> Handle(CommandInstrumentItem request, CancellationToken cancellationToken)
        {
            var Response = new InstrumentItemCommandResponse();

            var validator = new InstrumentItemValidator(_unitofwork.RepositoryMWOItemWithInstrument);
            var validationResult = await validator.ValidateAsync(request.MWOItem);//MWOItem esta vacio se espera que no se utilice este handler

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
                        var addcommand = _mapper.Map<AddInstrumentItem>(request);
                        var table = _mapper.Map<InstrumentItem>(addcommand);
                        table.AddDomainEvent(new CreatedEvent<InstrumentItem>(table));
                        table = await _unitofwork.RepositoryInstrumentItem.AddAsync(table);
                        await _unitofwork.Complete();
                        Response.InstrumentItemObject = _mapper.Map<CommandInstrumentItem>(table);
                        
                    }
                    else
                    {
                        var table = await _unitofwork.RepositoryInstrumentItem.FindAsync(request.Id);
                        if (table != null)
                        {
                            var addcommand = _mapper.Map<AddInstrumentItem>(request);
                            _mapper.Map(addcommand, table, typeof(AddInstrumentItem), typeof(InstrumentItem));
                            table.AddDomainEvent(new UpdatedEvent<InstrumentItem>(table));
                            await _unitofwork.RepositoryInstrumentItem.UpdateAsync(table);
                            await _unitofwork.Complete();
                            Response.InstrumentItemObject = _mapper.Map<CommandInstrumentItem>(table);
                     
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