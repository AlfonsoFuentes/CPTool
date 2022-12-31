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

namespace CPTool.ApplicationCQRS.Features.DeviceFunctionModifiers.Commands.CreateUpdate
{
    public class DeviceFunctionModifierCommandHandler : IRequestHandler<CommandDeviceFunctionModifier, DeviceFunctionModifierCommandResponse>
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;


        public DeviceFunctionModifierCommandHandler(IMapper mapper, IUnitOfWork unitofwork, IEmailService emailService)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
            _emailService = emailService;
        }

        public async Task<DeviceFunctionModifierCommandResponse> Handle(CommandDeviceFunctionModifier request, CancellationToken cancellationToken)
        {
            var Response = new DeviceFunctionModifierCommandResponse();

            var validator = new DeviceFunctionModifierValidator(_unitofwork.RepositoryDeviceFunctionModifier);
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
                        var addcommand = _mapper.Map<AddDeviceFunctionModifier>(request);
                        var table = _mapper.Map<DeviceFunctionModifier>(addcommand);
                        table.AddDomainEvent(new CreatedEvent<DeviceFunctionModifier>(table));
                        table = await _unitofwork.RepositoryDeviceFunctionModifier.AddAsync(table);
                        await _unitofwork.Complete();
                        Response.DeviceFunctionModifierObject = _mapper.Map<CommandDeviceFunctionModifier>(table);
                        
                    }
                    else
                    {
                        var table = await _unitofwork.RepositoryDeviceFunctionModifier.FindAsync(request.Id);
                        if (table != null)
                        {
                            var addcommand = _mapper.Map<AddDeviceFunctionModifier>(request);
                            _mapper.Map(addcommand, table, typeof(AddDeviceFunctionModifier), typeof(DeviceFunctionModifier));
                            table.AddDomainEvent(new UpdatedEvent<DeviceFunctionModifier>(table));
                            await _unitofwork.RepositoryDeviceFunctionModifier.UpdateAsync(table);
                            await _unitofwork.Complete();
                            Response.DeviceFunctionModifierObject = _mapper.Map<CommandDeviceFunctionModifier>(table);
                     
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