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

namespace CPTool.ApplicationCQRS.Features.TaxCodeLDs.Commands.CreateUpdate
{
    public class TaxCodeLDCommandHandler : IRequestHandler<CommandTaxCodeLD, TaxCodeLDCommandResponse>
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;


        public TaxCodeLDCommandHandler(IMapper mapper, IUnitOfWork unitofwork, IEmailService emailService)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
            _emailService = emailService;
        }

        public async Task<TaxCodeLDCommandResponse> Handle(CommandTaxCodeLD request, CancellationToken cancellationToken)
        {
            var Response = new TaxCodeLDCommandResponse();

            var validator = new TaxCodeLDValidator(_unitofwork.RepositoryTaxCodeLD);
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
                        var addcommand = _mapper.Map<AddTaxCodeLD>(request);
                        var table = _mapper.Map<TaxCodeLD>(addcommand);
                        table.AddDomainEvent(new CreatedEvent<TaxCodeLD>(table));
                        table = await _unitofwork.RepositoryTaxCodeLD.AddAsync(table);
                        await _unitofwork.Complete();
                        Response.TaxCodeLDObject = _mapper.Map<CommandTaxCodeLD>(table);
                        
                    }
                    else
                    {
                        var table = await _unitofwork.RepositoryTaxCodeLD.FindAsync(request.Id);
                        if (table != null)
                        {
                            var addcommand = _mapper.Map<AddTaxCodeLD>(request);
                            _mapper.Map(addcommand, table, typeof(AddTaxCodeLD), typeof(TaxCodeLD));
                            table.AddDomainEvent(new UpdatedEvent<TaxCodeLD>(table));
                            await _unitofwork.RepositoryTaxCodeLD.UpdateAsync(table);
                            await _unitofwork.Complete();
                            Response.TaxCodeLDObject = _mapper.Map<CommandTaxCodeLD>(table);
                     
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