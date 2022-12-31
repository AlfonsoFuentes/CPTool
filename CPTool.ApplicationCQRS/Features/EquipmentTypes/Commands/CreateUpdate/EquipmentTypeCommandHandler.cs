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

namespace CPTool.ApplicationCQRS.Features.EquipmentTypes.Commands.CreateUpdate
{
    public class EquipmentTypeCommandHandler : IRequestHandler<CommandEquipmentType, EquipmentTypeCommandResponse>
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;


        public EquipmentTypeCommandHandler(IMapper mapper, IUnitOfWork unitofwork, IEmailService emailService)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
            _emailService = emailService;
        }

        public async Task<EquipmentTypeCommandResponse> Handle(CommandEquipmentType request, CancellationToken cancellationToken)
        {
            var Response = new EquipmentTypeCommandResponse();

            var validator = new EquipmentTypeValidator(_unitofwork.RepositoryEquipmentType);
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
                        var addcommand = _mapper.Map<AddEquipmentType>(request);
                        var table = _mapper.Map<EquipmentType>(addcommand);
                        table.AddDomainEvent(new CreatedEvent<EquipmentType>(table));
                        table = await _unitofwork.RepositoryEquipmentType.AddAsync(table);
                        await _unitofwork.Complete();
                        Response.EquipmentTypeObject = _mapper.Map<CommandEquipmentType>(table);
                        
                    }
                    else
                    {
                        var table = await _unitofwork.RepositoryEquipmentType.FindAsync(request.Id);
                        if (table != null)
                        {
                            var addcommand = _mapper.Map<AddEquipmentType>(request);
                            _mapper.Map(addcommand, table, typeof(AddEquipmentType), typeof(EquipmentType));
                            table.AddDomainEvent(new UpdatedEvent<EquipmentType>(table));
                            await _unitofwork.RepositoryEquipmentType.UpdateAsync(table);
                            await _unitofwork.Complete();
                            Response.EquipmentTypeObject = _mapper.Map<CommandEquipmentType>(table);
                     
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