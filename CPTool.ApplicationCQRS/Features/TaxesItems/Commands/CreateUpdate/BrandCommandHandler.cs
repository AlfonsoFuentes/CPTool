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

namespace CPTool.ApplicationCQRS.Features.TaxesItems.Commands.CreateUpdate
{
    public class TaxesItemCommandHandler : IRequestHandler<CommandTaxesItem, TaxesItemCommandResponse>
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;


        public TaxesItemCommandHandler(IMapper mapper, IUnitOfWork unitofwork, IEmailService emailService)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
            _emailService = emailService;
        }

        public async Task<TaxesItemCommandResponse> Handle(CommandTaxesItem request, CancellationToken cancellationToken)
        {
            var Response = new TaxesItemCommandResponse();

            var validator = new TaxesItemValidator(_unitofwork.RepositoryTaxesItem);
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
                        var addcommand = _mapper.Map<AddTaxesItem>(request);
                        var table = _mapper.Map<TaxesItem>(addcommand);
                        table.AddDomainEvent(new CreatedEvent<TaxesItem>(table));
                        table = await _unitofwork.RepositoryTaxesItem.AddAsync(table);
                        await _unitofwork.Complete();
                        Response.TaxesItemObject = _mapper.Map<CommandTaxesItem>(table);
                        
                    }
                    else
                    {
                        var table = await _unitofwork.RepositoryTaxesItem.FindAsync(request.Id);
                        if (table != null)
                        {
                            var addcommand = _mapper.Map<AddTaxesItem>(request);
                            _mapper.Map(addcommand, table, typeof(AddTaxesItem), typeof(TaxesItem));
                            table.AddDomainEvent(new UpdatedEvent<TaxesItem>(table));
                            await _unitofwork.RepositoryTaxesItem.UpdateAsync(table);
                            await _unitofwork.Complete();
                            Response.TaxesItemObject = _mapper.Map<CommandTaxesItem>(table);
                     
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