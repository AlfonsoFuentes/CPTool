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

namespace CPTool.ApplicationCQRS.Features.PurchaseOrderItems.Commands.CreateUpdate
{
    public class PurchaseOrderItemCommandHandler : IRequestHandler<CommandPurchaseOrderItem, PurchaseOrderItemCommandResponse>
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;


        public PurchaseOrderItemCommandHandler(IMapper mapper, IUnitOfWork unitofwork, IEmailService emailService)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
            _emailService = emailService;
        }

        public async Task<PurchaseOrderItemCommandResponse> Handle(CommandPurchaseOrderItem request, CancellationToken cancellationToken)
        {
            var Response = new PurchaseOrderItemCommandResponse();

            var validator = new PurchaseOrderItemValidator(_unitofwork.RepositoryPurchaseOrderItem);
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
                        var addcommand = _mapper.Map<AddPurchaseOrderItem>(request);
                        var table = _mapper.Map<PurchaseOrderItem>(addcommand);
                        table.AddDomainEvent(new CreatedEvent<PurchaseOrderItem>(table));
                        table = await _unitofwork.RepositoryPurchaseOrderItem.AddAsync(table);
                        await _unitofwork.Complete();
                        Response.PurchaseOrderItemObject = _mapper.Map<CommandPurchaseOrderItem>(table);
                        
                    }
                    else
                    {
                        var table = await _unitofwork.RepositoryPurchaseOrderItem.FindAsync(request.Id);
                        if (table != null)
                        {
                            var addcommand = _mapper.Map<AddPurchaseOrderItem>(request);
                            _mapper.Map(addcommand, table, typeof(AddPurchaseOrderItem), typeof(PurchaseOrderItem));
                            table.AddDomainEvent(new UpdatedEvent<PurchaseOrderItem>(table));
                            await _unitofwork.RepositoryPurchaseOrderItem.UpdateAsync(table);
                            await _unitofwork.Complete();
                            Response.PurchaseOrderItemObject = _mapper.Map<CommandPurchaseOrderItem>(table);
                     
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