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

namespace CPTool.ApplicationCQRS.Features.EquipmentItems.Commands.CreateUpdate
{
    public class EquipmentItemCommandHandler : IRequestHandler<CommandEquipmentItem, EquipmentItemCommandResponse>
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;


        public EquipmentItemCommandHandler(IMapper mapper, IUnitOfWork unitofwork, IEmailService emailService)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
            _emailService = emailService;
        }

        public async Task<EquipmentItemCommandResponse> Handle(CommandEquipmentItem request, CancellationToken cancellationToken)
        {
            var Response = new EquipmentItemCommandResponse();

            var validator = new EquipmentItemValidator(_unitofwork.RepositoryEquipmentItem);
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
                        var addcommand = _mapper.Map<AddEquipmentItem>(request);
                        var table = _mapper.Map<EquipmentItem>(addcommand);
                        table.AddDomainEvent(new CreatedEvent<EquipmentItem>(table));
                        table = await _unitofwork.RepositoryEquipmentItem.AddAsync(table);
                        await _unitofwork.Complete();
                        Response.EquipmentItemObject = _mapper.Map<CommandEquipmentItem>(table);
                        
                    }
                    else
                    {
                        var table = await _unitofwork.RepositoryEquipmentItem.FindAsync(request.Id);
                        if (table != null)
                        {
                            var addcommand = _mapper.Map<AddEquipmentItem>(request);
                            _mapper.Map(addcommand, table, typeof(AddEquipmentItem), typeof(EquipmentItem));
                            table.AddDomainEvent(new UpdatedEvent<EquipmentItem>(table));
                            await _unitofwork.RepositoryEquipmentItem.UpdateAsync(table);
                            await _unitofwork.Complete();
                            Response.EquipmentItemObject = _mapper.Map<CommandEquipmentItem>(table);
                     
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