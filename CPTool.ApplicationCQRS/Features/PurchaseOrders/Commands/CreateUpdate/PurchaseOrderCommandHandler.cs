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
using Azure;
using CPTool.ApplicationCQRS.Features.PurchaseOrderItems.Commands.CreateUpdate;
using CPTool.Domain.Enums;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.PurchaseOrders.Commands.CreateUpdate
{
    public class PurchaseOrderCommandHandler : IRequestHandler<CommandPurchaseOrder, PurchaseOrderCommandResponse>
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;


        public PurchaseOrderCommandHandler(IMapper mapper, IUnitOfWork unitofwork, IEmailService emailService)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
            _emailService = emailService;
        }

        public async Task<PurchaseOrderCommandResponse> Handle(CommandPurchaseOrder request, CancellationToken cancellationToken)
        {
            var Response = new PurchaseOrderCommandResponse();

            var validator = new PurchaseOrderValidator(_unitofwork.RepositoryPurchaseOrder);
            var validationResult = await validator.ValidateAsync(request);
            var validatePurchasOrderItems =await  PurchaseorderItemsValidation(request);
            if (validationResult.Errors.Count > 0|| validatePurchasOrderItems.ValidationErrors.Count>0)
            {
                Response.Success = false;
                
                foreach (var error in validationResult.Errors)
                {
                    Response.ValidationErrors.Add(error.ErrorMessage);
                }
                Response.ValidationErrors.AddRange(validatePurchasOrderItems.ValidationErrors);
                
            }
            if (Response.Success)
            {
                try
                {
                    UpdatePurchaseorderStatus(request);
                    if (request.Id == 0)
                    {
                        var addcommand = _mapper.Map<AddPurchaseOrder>(request);
                        var table = _mapper.Map<PurchaseOrder>(addcommand);
                        table.AddDomainEvent(new CreatedEvent<PurchaseOrder>(table));
                        table = await _unitofwork.RepositoryPurchaseOrder.AddAsync(table);
                        await _unitofwork.Complete();
                        request.Id = table.Id;
                       
                        Response.PurchaseOrderObject = request;
                        
                    }
                    else
                    {
                        var table = await _unitofwork.RepositoryPurchaseOrder.FindAsync(request.Id);
                        if (table != null)
                        {
                            var addcommand = _mapper.Map<UpdatePurchaseOrder>(request);
                            _mapper.Map(addcommand, table, typeof(UpdatePurchaseOrder), typeof(PurchaseOrder));
                            table.AddDomainEvent(new UpdatedEvent<PurchaseOrder>(table));
                            await _unitofwork.RepositoryPurchaseOrder.UpdateAsync(table);
                            await _unitofwork.Complete();
                       
                            Response.PurchaseOrderObject = request;
                     
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

       void UpdatePurchaseorderStatus(CommandPurchaseOrder command)
        {
            if (command.PurchaseOrderStatus == PurchaseOrderApprovalStatus.Draft)
            {
                command.POOrderingdDate = DateTime.UtcNow;
                command.PurchaseOrderStatus = PurchaseOrderApprovalStatus.Ordering;
                command.CurrencyDate = DateTime.UtcNow;
            }

            else if (command.PurchaseOrderStatus == PurchaseOrderApprovalStatus.Ordering)
            {
                command.POCreatedDate = DateTime.Now;
                command.PurchaseOrderStatus = PurchaseOrderApprovalStatus.Created;
            }
            else if (command.PurchaseOrderStatus == PurchaseOrderApprovalStatus.Created)
            {
                if (command.pBrand.BrandType == BrandType.Brand)
                {
                    command.POReceivedDate = DateTime.Now;
                    command.PurchaseOrderStatus = PurchaseOrderApprovalStatus.Received;
                }
                else
                {
                    command.POReceivedDate = DateTime.Now;
                    command.PurchaseOrderStatus = PurchaseOrderApprovalStatus.Installed;
                    command.POInstalledDate = DateTime.Now;
                }

            }
            else if (command.PurchaseOrderStatus == PurchaseOrderApprovalStatus.Received)
            {
                command.POInstalledDate = DateTime.Now;
                command.PurchaseOrderStatus = PurchaseOrderApprovalStatus.Installed;
            }
            else if (command.PurchaseOrderStatus == PurchaseOrderApprovalStatus.Installed)
            {

                command.PurchaseOrderStatus = PurchaseOrderApprovalStatus.Closed;
            }
        }

        async Task<PurchaseOrderCommandResponse> PurchaseorderItemsValidation(CommandPurchaseOrder request)
        {
            PurchaseOrderCommandResponse result = new();
            foreach (var row in request.PurchaseOrderItems)
            {
                var validator = new PurchaseOrderItemValidator(_unitofwork.RepositoryPurchaseOrderItem);
                var validationResult = await validator.ValidateAsync(row);

                if (validationResult.Errors.Count > 0)
                {
                    result.Success = false;

                    foreach (var error in validationResult.Errors)
                    {
                        result.ValidationErrors.Add(error.ErrorMessage);
                    }
                }
            }
            return result;
        }
    }
}