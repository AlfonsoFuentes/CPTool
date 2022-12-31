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

namespace CPTool.ApplicationCQRS.Features.EquipmentTypeSubs.Commands.CreateUpdate
{
    public class EquipmentTypeSubCommandHandler : IRequestHandler<CommandEquipmentTypeSub, EquipmentTypeSubCommandResponse>
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;


        public EquipmentTypeSubCommandHandler(IMapper mapper, IUnitOfWork unitofwork, IEmailService emailService)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
            _emailService = emailService;
        }

        public async Task<EquipmentTypeSubCommandResponse> Handle(CommandEquipmentTypeSub request, CancellationToken cancellationToken)
        {
            var Response = new EquipmentTypeSubCommandResponse();

            var validator = new EquipmentTypeSubValidator(_unitofwork.RepositoryEquipmentTypeSub);
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
                        var addcommand = _mapper.Map<AddEquipmentTypeSub>(request);
                        var table = _mapper.Map<EquipmentTypeSub>(addcommand);
                        table.AddDomainEvent(new CreatedEvent<EquipmentTypeSub>(table));
                        table = await _unitofwork.RepositoryEquipmentTypeSub.AddAsync(table);
                        await _unitofwork.Complete();
                        Response.EquipmentTypeSubObject = _mapper.Map<CommandEquipmentTypeSub>(table);
                        
                    }
                    else
                    {
                        var table = await _unitofwork.RepositoryEquipmentTypeSub.FindAsync(request.Id);
                        if (table != null)
                        {
                            var addcommand = _mapper.Map<AddEquipmentTypeSub>(request);
                            _mapper.Map(addcommand, table, typeof(AddEquipmentTypeSub), typeof(EquipmentTypeSub));
                            table.AddDomainEvent(new UpdatedEvent<EquipmentTypeSub>(table));
                            await _unitofwork.RepositoryEquipmentTypeSub.UpdateAsync(table);
                            await _unitofwork.Complete();
                            Response.EquipmentTypeSubObject = _mapper.Map<CommandEquipmentTypeSub>(table);
                     
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